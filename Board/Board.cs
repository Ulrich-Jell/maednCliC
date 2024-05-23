using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using maednCls.Game;
using maednCls.Helper;
using maednCls.Meeples;
using Microsoft.VisualBasic.FileIO;
using Pastel;

namespace maednCls.Board
{
    public class GameBoard
    {
        public List<List<string>> Coordinates { get; set; }
        public List<Player> Players {get; set;}


        public GameBoard()
        {
            Coordinates = new List<List<string>>();
            Players = new List<Player>();
        }
        
        public void ImportBoard(List<Player> players)
        {            
            Players = players;
            bool isWindows = OperatingSystem.IsWindows();
            bool isLinux = OperatingSystem.IsLinux();
            
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = "";


            if (isWindows)
                sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Board\board.csv");
            else if (isLinux)
            {
                string debug = @"/bin/Debug/net6.0/";
                string dir = sCurrentDirectory.Substring(0, sCurrentDirectory.Length - debug.Length);
                sFile = dir + "/Board/board.csv";
            }
            string sFilePath = Path.GetFullPath(sFile);


            using (TextFieldParser csvParser = new TextFieldParser(sFilePath))
            {
                csvParser.SetDelimiters(new string[] { ";" });              
                
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    List<String> boardString = new List<String>();
                    string[] fields = csvParser.ReadFields();
                    foreach (string field in fields)
                        boardString.Add(field);

                    Coordinates.Add(boardString);                    
                }
            }
        }

        public void PrintBoard()
        {
            Console.Clear();
            List<string> meeples0 = new List<String>() { "11", "12", "13", "14" };
            List<string> meeples1 = new List<String>() { "21", "22", "23", "24" };
            List<string> meeples2 = new List<String>() { "31", "32", "33", "34" };
            List<string> meeples3 = new List<String>() { "41", "42", "43", "44" };
            List<string> lines = new List<String>() { "()","()", "--","--", "|.", "| "};

            var spectrum = new (string square, string color)[21];
            foreach (List<string> row in Coordinates)
            {
                int c = 0;
                foreach (string s in row)
                {
                    if (s == "..")
                        spectrum[c] = ("..", "000000");
                    else if (lines.Contains(s))
                        spectrum[c] = (lines[lines.IndexOf(s)+1], "FFFFFF");
                    else if (s == "H1" || s == "G1" || s == "S1")
                        spectrum[c] = ("()", Players[0].Color);
                    else if (s == "X1")
                        spectrum[c] = ("##", Players[0].Color);
                    else if (s == "H2" || s == "G2" || s == "S2")
                        spectrum[c] = ("()", Players[1].Color);
                    else if (s == "H3" || s == "G3" || s == "S3")
                        spectrum[c] = ("()", Players[2].Color);
                    else if (s == "H4" || s == "G4" || s == "S4")
                        spectrum[c] = ("()", Players[3].Color);
                    else if (meeples0.Contains(s))
                        spectrum[c] = (meeples0[meeples0.IndexOf(s)], Players[0].Color);
                    else if (meeples1.Contains(s))
                        spectrum[c] = (meeples1[meeples1.IndexOf(s)], Players[1].Color);
                    else if (meeples2.Contains(s))
                        spectrum[c] = (meeples2[meeples2.IndexOf(s)], Players[2].Color);
                    else if (meeples3.Contains(s))
                        spectrum[c] = (meeples3[meeples3.IndexOf(s)], Players[3].Color);
                    else
                        spectrum[c] = ("XX", "FF00E8");

                    c++;
                }
                Console.WriteLine(string.Join("", spectrum.Select(s => s.square.Pastel(s.color)))); ;
            }
            Thread.Sleep(1500);
        }

        public Meeple MoveMeeple(Meeple m, int steps)
        {
            for (int i = 0; i < steps -1; i++)
                m = MoveMeepleOneStep(m);

            m = MoveMeepleLastStep(m);

            return m;
        }

        public Meeple BringMeepleIn(Meeple m)
        {
            Coordinates[m.OutSquare.Item1][m.OutSquare.Item2] = "S" + m.Player.ID.ToString();

            m.Buffer = "S" + m.Player.ID.ToString();
            m.Position = m.Player.RouteOffset;

            int xNew = Constants.Route[m.Position].Row;
            int yNew = Constants.Route[m.Position].Spot;

            if (Coordinates[xNew][yNew].StartsWith("S"))                
            {
                m.Buffer = Coordinates[xNew][yNew];
                Coordinates[xNew][yNew] = m.DisplayName;
            }
            else
                return ThrowMeepleOut(m);                
            
            PrintBoard();
            return m;
        }

        private Meeple MoveMeepleOneStep(Meeple m)
        {
            if (m.Progress == Constants.Route.Count)
                MoveMeepleInHome(m);            

            m = LeaveSquare(m);

            int newPosition = m.UpdatePosition();

            int xNew = Constants.Route[newPosition].Row;
            int yNew = Constants.Route[newPosition].Spot;

            if (Coordinates[xNew][yNew] != "()")
                m.Buffer = Coordinates[xNew][yNew];

            Coordinates[xNew][yNew] = m.DisplayName;
            m.Position = newPosition;
            PrintBoard();
            return m;
        }

        private Meeple MoveMeepleLastStep(Meeple m)
        {
            if (m.Progress == Constants.Route.Count)
                MoveMeepleInHome(m);            

            m = LeaveSquare(m);

            int newPosition = m.UpdatePosition();
            
            int xNew = Constants.Route[newPosition].Row;
            int yNew = Constants.Route[newPosition].Spot;

            if (Coordinates[xNew][yNew] != "()")
            {
                if (!Coordinates[xNew][yNew].StartsWith("S"))
                {
                    m.Position = newPosition;
                    return ThrowMeepleOut(m);
                }
                else
                    m.Buffer = Coordinates[xNew][yNew];                
            }

            Coordinates[xNew][yNew] = m.DisplayName;
            m.Position = newPosition;
            PrintBoard();
            return m;
        }

        private Meeple LeaveSquare(Meeple m)
        {
            int xOld = Constants.Route[m.Position].Row;
            int yOld = Constants.Route[m.Position].Spot;

            if (m.Buffer != string.Empty)
            {
                Coordinates[xOld][yOld] = m.Buffer;
                m.Buffer = string.Empty;
            }
            else
                Coordinates[xOld][yOld] = "()";

            return m;
        }

        private Meeple ThrowMeepleOut(Meeple m)
        {
            int x = Constants.Route[m.Position].Row;
            int y = Constants.Route[m.Position].Spot;

            Square outSquare = Constants.AllOuts.Where(o => o.DefaultContent == Coordinates[x][y]).First();

            Coordinates[outSquare.Row][outSquare.Spot] = outSquare.DefaultContent;
            Coordinates[x][y] = m.DisplayName;
            PrintBoard();
            return m;
        }

        private void MoveMeepleInHome(Meeple m)
        {
            
        }

        
    }
}
