using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Board;
using maednCls.Helper;
using maednCls.Meeples;

namespace maednCls.Game
{
    public class Player
    {
        public bool IsPlaying { get; set; }
        public int ID { get; set; }
        public string Name {get; set;}
        public string Color { get; set; }
        public int RouteOffset { get; set; }
        public List<Meeple> Meeples { get; set; }

        public Player (bool isPlaying, int id, string name, string color, int startPosition)
        {
            IsPlaying = isPlaying;
            ID = id;
            Name = name;
            Color = color;
            RouteOffset = startPosition;
            Meeples = new List<Meeple>();
        }

        public Movement MakeTurn(List<Square> matchStatus, Board.Board board)
        {
            Random r = new Random();
            List<Meeple> meeplesOnTour = Meeples.Where(x => x.Progress > 0).ToList();
            List<Meeple> movedMeeples = new();
            List<Meeple> meeplesAtBeginning = Meeples;
            
            if(meeplesOnTour.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int dice = r.Next(5,7);
                    System.Console.WriteLine(dice);
                    if (dice == 6)
                    {
                        matchStatus = board.MoveMeepleFromHome(Meeples.Where(x => x.Progress == 0).First(), matchStatus);
                        dice = r.Next(1,7);
                        System.Console.WriteLine($"{Name} rolls a {dice}.");
                        System.Console.ReadKey();
                        Movement move = board.MoveMeeple(Meeples.Where(x => x.Progress == 1).First(), dice, matchStatus);
                        matchStatus = move.MatchStatus;
                        break;
                    }
                }
            }

            foreach (Meeple m in MovedOwnMeeples(meeplesAtBeginning))
                movedMeeples.Add(m);

            
            return new Movement(matchStatus, movedMeeples);
        }

        private List<Meeple> MovedOwnMeeples(List<Meeple> atBeginning)
        {
            List<Meeple> movedMepples = new();
            for (int i = 0; i < Meeples.Count; i++)
            {
                if (atBeginning[i].Progress != Meeples[i].Progress)
                    movedMepples.Add(Meeples[i]);

            } 
        }

       

    }
}
