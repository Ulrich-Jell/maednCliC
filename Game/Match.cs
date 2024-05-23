using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Board;
using maednCls.Meeples;
using System.Xml.Schema;
using maednCls.Helper;

namespace maednCls.Game
{
    public class Match
    {

        public GameBoard Board {get; set;}
        public List<Player> Players { get; set; }
        public List<Meeple> AllMeeples { get; set; }
        public static bool SomeoneHasWon { get; set; }
        private MovementManager mm {get; set;}
        public Player ActivePlayer {get; set;}

        public Match()
        {
            Board = new GameBoard();
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
            ActivePlayer = one;

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

            List<Square> outPlayer1 = Constants.OutPlayer1;
            List<Square> outPlayer2 = Constants.OutPlayer2;
            List<Square> outPlayer3 = Constants.OutPlayer3;
            List<Square> outPlayer4 = Constants.OutPlayer4;

            for (int i = 0; i < AllMeeples.Count; i++)
            {
                if (i < 4)
                {
                    //one.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i].OutSquare = (outPlayer1[i].Row, outPlayer1[i].Spot);
                    outPlayer1[i].Occupant = AllMeeples[i];
                }
                    
                else if (i < 8)
                {
                    //two.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i].OutSquare = (outPlayer2[i - 4].Row, outPlayer2[i - 4].Spot);
                    outPlayer2[i - 4].Occupant = AllMeeples[i];
                }
                else if (i < 12)
                {
                    //three.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i].OutSquare = (outPlayer3[i - 8].Row, outPlayer3[i - 8].Spot);
                    outPlayer3[i - 8].Occupant = AllMeeples[i];
                }
                else
                {
                    //four.Meeples.Add(AllMeeples[i]);
                    AllMeeples[i].OutSquare = (outPlayer4[i - 12].Row, outPlayer4[i - 12].Spot);
                    outPlayer4[i - 12].Occupant = AllMeeples[i];
                }
            }

            mm = new MovementManager(AllMeeples, Board)
            {
                ActivePlayer = Players[0]
            };

            var x = Constants.Route.Last().Row;
            var y = Constants.Route.Last().Spot;

            AllMeeples[6].Position = Constants.Route.Count - 1;
            Board.Coordinates[x][y] = "23";

            Board.PrintBoard();

            AllMeeples[6] = Board.MoveMeeple(AllMeeples[6], 2);

        }

        public void Start()
        { 
            NextPlayer();
        }


        public void NextPlayer()
        {
            if (ActivePlayer.ID == 4)
                ActivePlayer = Players[0];
            else
                ActivePlayer = Players[ActivePlayer.ID];
        }

        

    }
}
