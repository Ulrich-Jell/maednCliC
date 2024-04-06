using maednCls.Board;
using maednCls.Game;
using Pastel;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Tools
{
    public class DrawBoard
    {    
        public Board.Board Board { get; set; }
        public List<Player> Players { get; set; }

        public DrawBoard (Board.Board board = null, List<Player> players = null)
        {
            Board = board;
            Players = players;
        }

        public void Print()
        {
            Console.Clear();
            List<string> meeples0 = new List<String>() { "11", "12", "13", "14" };
            List<string> meeples1 = new List<String>() { "21", "22", "23", "24" };
            List<string> meeples2 = new List<String>() { "31", "32", "33", "34" };
            List<string> meeples3 = new List<String>() { "41", "42", "43", "44" };
            List<string> lines = new List<String>() { "()","()", "--","--", "|.", "| "};

            var spectrum = new (string square, string color)[21];
            foreach (List<string> row in this.Board.Coordinates)
            {
                int c = 0;
                foreach (string s in row)
                {
                    if (s == "..")
                        spectrum[c] = ("..", "000000");
                    else if (lines.Contains(s))
                        spectrum[c] = (lines[lines.IndexOf(s)+1], "FFFFFF");
                    else if (s == "H1" || s == "G1" || s == "S1")
                        spectrum[c] = ("()", this.Players[0].Color);
                    else if (s == "X1")
                        spectrum[c] = ("##", this.Players[0].Color);
                    else if (s == "H2" || s == "G2" || s == "S2")
                        spectrum[c] = ("()", this.Players[1].Color);
                    else if (s == "H3" || s == "G3" || s == "S3")
                        spectrum[c] = ("()", this.Players[2].Color);
                    else if (s == "H4" || s == "G4" || s == "S4")
                        spectrum[c] = ("()", this.Players[3].Color);
                    else if (meeples0.Contains(s))
                        spectrum[c] = (meeples0[meeples0.IndexOf(s)], this.Players[0].Color);
                    else if (meeples1.Contains(s))
                        spectrum[c] = (meeples1[meeples1.IndexOf(s)], this.Players[1].Color);
                    else if (meeples2.Contains(s))
                        spectrum[c] = (meeples2[meeples2.IndexOf(s)], this.Players[2].Color);
                    else if (meeples3.Contains(s))
                        spectrum[c] = (meeples3[meeples3.IndexOf(s)], this.Players[3].Color);
                    else
                        spectrum[c] = ("__", "FF00E8");

                    c++;
                }
                Console.WriteLine(string.Join("", spectrum.Select(s => s.square.Pastel(s.color)))); ;
            }
        }

        public void NewPrint(Route r)
        {
            List<Square> routeSorted = r.Steps.OrderBy(o => o.Row).ToList();

            foreach (var  square in routeSorted)
            {
                Console.WriteLine(square.Row + "/" + square.Spot);
            }

            for (int i = 0; i < Board.Coordinates.Count; i++)
            {

            }
        }
    }
}
