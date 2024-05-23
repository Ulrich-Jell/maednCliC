using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Game;
using maednCls.Board;
using maednCls.Helper;

namespace maednCls.Meeples
{
    public class Meeple
    {
        public Player Player { get; set; }
        public string DisplayName { get; set; }
        public (int, int) OutSquare { get; set;}
        public int Position { get; set;}
        public int Progress { get; set; }
        public Status Status {get; set;}
        public string Buffer {get; set;}




        public Meeple(Player player, string no, int progress)
        {
            Player = player;
            DisplayName = no;
            Progress = progress;
            Status = Status.outArea;
            Buffer = "";
        }

        public Meeple()
        {
            Player = new Player(false, 0, "none", 0);
            DisplayName = "()";
            Progress = 0;
        }

        public int UpdatePosition()
        {
            if (Position == Constants.Route.Count - 1)
                return 0;
            else
                return Position + 1;
        }
    } 
}
