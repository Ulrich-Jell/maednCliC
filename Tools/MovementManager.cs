using maednCls.Board;
using maednCls.Game;
using maednCls.Meeples;

namespace maednCls.Helper
{
    public class MovementManager
    {
        public GameBoard Board {get; set;}
        public List<Meeple> Meeples {get; set;}
        public List<Player> Players {get; set;}

        public Player ActivePlayer {get; set;}

        public MovementManager (List<Meeple> meeples, GameBoard board)
        {
            Meeples = meeples;
            Board = board;
        }




    }
}