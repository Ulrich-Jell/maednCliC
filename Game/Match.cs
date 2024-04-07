using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Board;
using maednCls.Tools;
using maednCls.Meeples;
using System.Xml.Schema;

namespace maednCls.Game
{
    public class Match
    {

        public Board.Board Board {get; set;}
        public DrawBoard  Printer { get; set; }
        public List<Square> Route { get; set; }
        public List<Player> Players { get; set; }
        public List<Meeple> AllMeeples { get; set; }
        public static bool SomeoneHasWon { get; set; }

        public Match()
        {
            Board = new Board.Board();
            Printer = new DrawBoard();
            Players = new List<Player>();
            AllMeeples = new List<Meeple>();
            SomeoneHasWon = false;
        }

        public void SetUp()
        {
            Player one = new Player(false, 1, "DAE504", 0);
            Player two = new Player(false, 2, "28B463", 10);
            Player three = new Player(true, 3, "E74C3C", 20);
            Player four = new Player(false, 4, "3498DB",  30);
            
            Players.Add(one); Players.Add(two); Players.Add(three); Players.Add(four);

            Board.ImportBoard(Players);

            AllMeeples.Add(new Meeple(one, "11", 0, "H1"));
            AllMeeples.Add(new Meeple(one, "12", 0, "H1"));
            AllMeeples.Add(new Meeple(one, "13", 0, "H1"));
            AllMeeples.Add(new Meeple(one, "14", 0, "H1"));
            AllMeeples.Add(new Meeple(two, "21",  0, "H2"));
            AllMeeples.Add(new Meeple(two, "22", 0, "H2"));
            AllMeeples.Add(new Meeple(two, "23", 0, "H2"));
            AllMeeples.Add(new Meeple(two, "24", 0, "H2"));
            AllMeeples.Add(new Meeple(three, "31", 0, "H3"));
            AllMeeples.Add(new Meeple(three, "32", 0, "H3"));
            AllMeeples.Add(new Meeple(three, "33", 0, "H3"));
            AllMeeples.Add(new Meeple(three, "34", 0, "H3"));
            AllMeeples.Add(new Meeple(four, "41", 0, "H4"));
            AllMeeples.Add(new Meeple(four, "42", 0, "H4"));
            AllMeeples.Add(new Meeple(four, "43", 0, "H4"));
            AllMeeples.Add(new Meeple(four, "44", 0, "H4"));

            List<Square> homePlayer1 = Constants.HomePlayer1;
            List<Square> homePlayer2 = Constants.HomePlayer2;
            List<Square> homePlayer3 = Constants.HomePlayer3;
            List<Square> homePlayer4 = Constants.HomePlayer4;

            for (int i = 0; i < AllMeeples.Count; i++)
            {
                if (i < 4)
                {
                    one.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i].Home = (homePlayer1[i].Row, homePlayer1[i].Spot);
                    homePlayer1[i].Occupant = AllMeeples[i];
                }
                    
                else if (i < 8)
                {
                    two.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i - 4].Home = (homePlayer2[i - 4].Row, homePlayer2[i - 4].Spot);
                    homePlayer2[i - 4].Occupant = AllMeeples[i];
                }
                else if (i < 12)
                {
                    three.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i - 8].Home = (homePlayer3[i - 8].Row, homePlayer2[i - 8].Spot);
                    homePlayer3[i - 8].Occupant = AllMeeples[i];
                }
                else
                {
                    four.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i - 12].Home = (homePlayer3[i - 12].Row, homePlayer2[i - 12].Spot);
                    homePlayer4[i - 12].Occupant = AllMeeples[i];
                }
            }

            Route = Constants.Route;

            // Route.Steps[1].Occupant = AllMeeples[5];

            Route[2].Occupant = two.Meeples[3];
            Board.Coordinates[Route[2].Row][Route[2].Spot] = two.Meeples[3].DisplayName;

            Route = Board.MoveMeepleFromHome(one.Meeples[0], Route);

            //Board.MoveMeeple(one.Meeples[2], 5, Route);

            //Board.PrintBoard();
            //Printer.NewPrint(Route);
       
        }

        public void Start()
        {
            _ = new Move(Players, AllMeeples);
        }

    }
}
