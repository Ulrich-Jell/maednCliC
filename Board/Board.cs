using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using maednCls.Game;
using maednCls.Meeples;
using Microsoft.VisualBasic.FileIO;
using Pastel;

namespace maednCls.Board
{
    public class Board
    {
        public List<List<string>> Coordinates { get; set; }
        public List<Player> Players {get; set;}

        public Board()
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
            List<string> meeples0 = new() { "11", "12", "13", "14" };
            List<string> meeples1 = new() { "21", "22", "23", "24" };
            List<string> meeples2 = new() { "31", "32", "33", "34" };
            List<string> meeples3 = new() { "41", "42", "43", "44" };
            List<string> lines = new() { "()","()", "--","--", "|.", "| "};

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

        public (List<Square>, List<Meeple>)  MoveMeeple(Meeple m, int steps, List<Square> route)
        {
            for (int i = 0; i < steps - 1; i++)
            {
                route = MoveMeepleOneStep(m, route);                
            }

            return MoveMeepleLastStep(m, route);
        }

        public List<Square> MoveMeepleOneStep(Meeple m, List<Square> route)
        {

            (Square, Square) startStop = GetStartStopPosition(m, route);
            Square start = startStop.Item1;

            if (start.Occupant.DisplayName == m.DisplayName)
            {
                start.CurrentContent = start.DefaultContent;
                Coordinates[start.Row][start.Spot] = start.DefaultContent;
            }
            else if (start.Occupant.DisplayName != "()")
            {
                start.CurrentContent = start.Occupant.DisplayName;
                Coordinates[start.Row][start.Spot] = start.Occupant.DisplayName;
            }
            else
            {
                start.CurrentContent = start.DefaultContent;
                Coordinates[start.Row][start.Spot] = start.DefaultContent;
            } 
            
            m.Progress ++;

            Square stop = startStop.Item2;
            stop.CurrentContent = m.DisplayName;
            Coordinates[stop.Row][stop.Spot] = m.DisplayName;

            PrintBoard();
            return route;
        }

        public (List<Square>, List<Meeple>) MoveMeepleLastStep(Meeple m, List<Square> route)
        {
            Square stop = GetStartStopPosition(m, route).Item2;
            if (stop.Occupant.DisplayName != "()")
            {
                return TakeMeeple(m, route);
            }
            else
            {
                route = MoveMeepleOneStep(m, route);
            }
            return (route, new List<Meeple>(){m});
        }

        public (List<Square>, List<Meeple>) TakeMeeple(Meeple m, List<Square> route)
        {
            (Square, Square) startStop = GetStartStopPosition(m, route);
            
            Square start = startStop.Item1;
            
            if (start.Occupant.DisplayName == m.DisplayName)
            {
                start.CurrentContent = start.DefaultContent;
                Coordinates[start.Row][start.Spot] = start.DefaultContent;
            }
            else
            {
                start.CurrentContent = start.Occupant.DisplayName;
                Coordinates[start.Row][start.Spot] = start.Occupant.DisplayName;
            }

            m.Progress ++;

            Square stop = startStop.Item2;
            Meeple takenMeeple = stop.Occupant;
            Coordinates[takenMeeple.Home.Item1][takenMeeple.Home.Item2] = takenMeeple.DisplayName;

            stop.CurrentContent = m.DisplayName;
            Coordinates[stop.Row][stop.Spot] = m.DisplayName;

            PrintBoard();

            return (route, new List<Meeple>(){m, takenMeeple});
        }

        public List<Square> MoveMeepleFromHome(Meeple m, List<Square> route)
        {
            Square start = route[m.Player.RouteOffset];
            route[m.Player.RouteOffset].Occupant = m;
            Coordinates[start.Row][start.Spot] = m.DisplayName;
            Coordinates[m.Home.Item1][m.Home.Item2] = "S" + m.Player.ID;

            PrintBoard();

            route[m.Player.RouteOffset].Occupant = new Meeple();
            
            return route;
        }

        private (Square, Square) GetStartStopPosition(Meeple m, List<Square> route)
        {
            int position = m.Progress + m.Player.RouteOffset;
            
            if (position > route.Count)
                position -= route.Count;

            Square start = route[position - 1];

            if (position == route.Count)
                position = 1;
            else
                position ++;

            Square stop= route[position - 1];

            return (start, stop);


        }
    }
}
