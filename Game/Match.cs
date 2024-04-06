using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Board;
using maednCls.Tools;
using maednCls.Meeples;

namespace maednCls.Game
{
    public class Match
    {

        public Board.Board Board {get; set;}
        public DrawBoard  Printer { get; set; }
        public Route Route { get; set; }
        public List<Player> Players { get; set; }
        public List<Meeple> AllMeeples { get; set; }
        public static bool SomeoneHasWon { get; set; }

        public Match()
        {
            Board = new Board.Board();
            Printer = new DrawBoard();
            Route = new Route();
            Players = new List<Player>();
            AllMeeples = new List<Meeple>();
            SomeoneHasWon = false;
        }

        public void SetUp()
        {
            

            Player zero = new Player(false, 1, "DAE504", 0);
            Player one = new Player(false, 2, "28B463", 10);
            Player two = new Player(true, 3, "E74C3C", 20);
            Player three = new Player(false, 4, "3498DB",  30);
            
            Players.Add(zero); Players.Add(one); Players.Add(two); Players.Add(three);

            Board.ImportBoard(Players);

            AllMeeples.Add(new Meeple(zero, "11", new HomeSquare(2, 3, "H1"), 0, "H1"));
            AllMeeples.Add(new Meeple(zero, "12", new HomeSquare(2, 5, "H1"), 0, "H1"));
            AllMeeples.Add(new Meeple(zero, "13", new HomeSquare(4, 3, "H1"), 0, "H1"));
            AllMeeples.Add(new Meeple(zero, "14", new HomeSquare(4, 5, "H1"), 0, "H1"));
            AllMeeples.Add(new Meeple(one, "21", new HomeSquare(2, 15, "H2"), 0, "H2"));
            AllMeeples.Add(new Meeple(one, "22", new HomeSquare(2, 17, "H2"), 0, "H2"));
            AllMeeples.Add(new Meeple(one, "23", new HomeSquare(4, 15, "H2"), 0, "H2"));
            AllMeeples.Add(new Meeple(one, "24", new HomeSquare(4, 17, "H2"), 0, "H2"));
            AllMeeples.Add(new Meeple(two, "31", new HomeSquare(16, 15, "H3"), 0, "H3"));
            AllMeeples.Add(new Meeple(two, "32", new HomeSquare(16, 17, "H3"), 0, "H3"));
            AllMeeples.Add(new Meeple(two, "33", new HomeSquare(18, 15, "H3"), 0, "H3"));
            AllMeeples.Add(new Meeple(two, "34", new HomeSquare(18, 17, "H3"), 0, "H3"));
            AllMeeples.Add(new Meeple(three, "41", new HomeSquare(16, 3, "H4"), 0, "H4"));
            AllMeeples.Add(new Meeple(three, "42", new HomeSquare(16, 5, "H4"), 0, "H4"));
            AllMeeples.Add(new Meeple(three, "43", new HomeSquare(18, 3, "H4"), 0, "H4"));
            AllMeeples.Add(new Meeple(three, "44", new HomeSquare(18, 5, "H4"), 0, "H4"));

            for (int i = 0; i < AllMeeples.Count; i++)
            {
                if (i < 4)
                    zero.Meeples.Add(AllMeeples[i]);
                else if (i < 8)
                    one.Meeples.Add(AllMeeples[i]);
                else if (i < 12)
                    two.Meeples.Add(AllMeeples[i]);
                else
                    three.Meeples.Add(AllMeeples[i]);
            }

            

            Printer.Board = Board;
            Printer.Players = Players;

            Board.MoveMeeple();

            Printer.Print();
       
        }

        public void Start()
        {
            _ = new Move(Players, AllMeeples);
        }

    }
}
