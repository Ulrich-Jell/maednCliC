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
        public List<Square> Route { get; set; }
        public List<Player> Players { get; set; }
        public List<Meeple> AllMeeples { get; set; }
        public static bool SomeoneHasWon { get; set; }

        public Match()
        {
            Board = new Board.Board();
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

            AllMeeples.Add(new Meeple(one, "11", 0));
            AllMeeples.Add(new Meeple(one, "12", 0));
            AllMeeples.Add(new Meeple(one, "13", 0));
            AllMeeples.Add(new Meeple(one, "14", 0));
            AllMeeples.Add(new Meeple(two, "21",  0));
            AllMeeples.Add(new Meeple(two, "22", 0));
            AllMeeples.Add(new Meeple(two, "23", 0));
            AllMeeples.Add(new Meeple(two, "24", 0));
            AllMeeples.Add(new Meeple(three, "31", 0));
            AllMeeples.Add(new Meeple(three, "32", 0));
            AllMeeples.Add(new Meeple(three, "33", 0));
            AllMeeples.Add(new Meeple(three, "34", 0));
            AllMeeples.Add(new Meeple(four, "41", 0));
            AllMeeples.Add(new Meeple(four, "42", 0));
            AllMeeples.Add(new Meeple(four, "43", 0));
            AllMeeples.Add(new Meeple(four, "44", 0));

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
                    AllMeeples[i].Home = (homePlayer2[i - 4].Row, homePlayer2[i - 4].Spot);
                    homePlayer2[i - 4].Occupant = AllMeeples[i];
                }
                else if (i < 12)
                {
                    three.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i].Home = (homePlayer3[i - 8].Row, homePlayer3[i - 8].Spot);
                    homePlayer3[i - 8].Occupant = AllMeeples[i];
                }
                else
                {
                    four.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i].Home = (homePlayer4[i - 12].Row, homePlayer4[i - 12].Spot);
                    homePlayer4[i - 12].Occupant = AllMeeples[i];
                }
            }

            Route = Constants.Route;

            Route = PlaceMeeple(Route, one.Meeples[0], 5);
            Route = PlaceMeeple(Route, two.Meeples[3], 5);
            Route = PlaceMeeple(Route, three.Meeples[1], 13);
            Route = PlaceMeeple(Route, three.Meeples[0],14);
            Route = PlaceMeeple(Route, four.Meeples[2], 5);


            Board.PrintBoard();

            MoveMeeple(three.Meeples[1], 3);
        }

        public void Start()
        {
            while (!SomeoneHasWon)
            {
                System.Console.WriteLine("Play the Game called 'Mensch ärgere dich nicht!'");
                SomeoneHasWon = true;
            }
        }

        public List<Square> PlaceMeeple(List<Square> route, Meeple meeple, int position)
        {
            int posOnBoard = position + meeple.Player.RouteOffset -1;
            if (posOnBoard > route.Count())
                posOnBoard = posOnBoard - route.Count();
            
            Route[posOnBoard].Occupant = meeple;
            Board.Coordinates[Route[posOnBoard].Row][Route[posOnBoard].Spot] = meeple.DisplayName;

            //System.Console.WriteLine(meeple.Home.Item1 + "---" + meeple.Home.Item2 + "----" + meeple.Player.ID);

            Board.Coordinates[meeple.Home.Item1][meeple.Home.Item2] = "S" + meeple.Player.ID;
            AllMeeples.Where(x => x.DisplayName == meeple.DisplayName).First().Progress = position;
            return route;
        }

        public void MoveMeeple(Meeple meeple, int steps)
        {
            (List<Square>, List<Meeple>) moveResult = Board.MoveMeeple(meeple, steps, Route);
            
            Route = moveResult.Item1;
            foreach (Meeple m in moveResult.Item2)
            {
                AllMeeples.Where(x => x.DisplayName == m.DisplayName).First().Progress = m.Progress;
            }
        }

    }
}
