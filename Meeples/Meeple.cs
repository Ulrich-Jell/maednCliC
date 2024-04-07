using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Game;
using maednCls.Board;
using maednCls.Tools;

namespace maednCls.Meeples
{
    public class Meeple
    {
        public Player Player { get; set; }
        public string DisplayName { get; set; }
        public (int, int) Home { get; set;}
        public int Progress { get; set; }
        public string LastContent { get; set; }
        public int LastPosition { get; set; }




        public Meeple(Player player, string no, int progress, string lastContent, int lastPosition = 1860)
        {
            Player = player;
            DisplayName = no;
            Progress = progress;
            LastContent = lastContent;
            LastPosition = lastPosition;

        }

        public Meeple()
        {
            Player = new Player(false, 0, "none", 0);
            DisplayName = "";
            Progress = 0;
            LastContent = "";
            LastPosition = 0;
        }
    } 
}
