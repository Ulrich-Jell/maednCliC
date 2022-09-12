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
        public string No { get; set; }
        public HomeSquare Home { get; }
        public int Progress { get; set; }
        public string LastContent { get; set; }
        public int LastPosition { get; set; }
        public ToolBelt Tools { get; set; }



        public Meeple(Player player, string no, HomeSquare home, int progress, string lastContent, ToolBelt tools, int lastPosition = 1860)
        {
            Player = player;
            No = no;
            Home = home;
            Progress = progress;
            LastContent = lastContent;
            LastPosition = lastPosition;
            Tools = tools;

        }

        public void test(Route r, ImportBoard board, DrawBoard drawer)
        {
            int step = this.Progress - this.Player.RouteCorrector;
            if (step < 0)
                step += r.Steps.Count;

            Console.WriteLine("{0} --- {1}", r.Steps[step].XPosition, r.Steps[step].YPosition);

            List<int> currentPosition = new List<int>() { r.Steps[step].XPosition , r.Steps[step].YPosition };

            board.Coordinate[r.Steps[step].XPosition][r.Steps[step].YPosition] = this.No;
            //drawer.draw();
        }

        public void getMovement()
        {
            
            if (this.LastPosition == 1860)
                this.Home.move(this);
            else
                this.Tools.Route.Steps[this.Progress].move(this);           
            
        }
    } 
}
