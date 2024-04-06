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




        public Meeple(Player player, string no, HomeSquare home, int progress, string lastContent, int lastPosition = 1860)
        {
            Player = player;
            No = no;
            Home = home;
            Progress = progress;
            LastContent = lastContent;
            LastPosition = lastPosition;

        }

        public void test(Route r, Board.Board board, DrawBoard drawer)
        {
            int step = this.Progress - this.Player.StartPosition;
            if (step < 0)
                step += r.Steps.Count;

            Console.WriteLine("{0} --- {1}", r.Steps[step].Row, r.Steps[step].Spot);

            List<int> currentPosition = new List<int>() { r.Steps[step].Row , r.Steps[step].Spot };

            board.Coordinates[r.Steps[step].Row][r.Steps[step].Spot] = this.No;
            //drawer.draw();
        }

        public void getMovement()
        {
            
            //if (this.LastPosition == 1860)
            //    this.Home.move(this);
            //else
            //    this.Tools.Route.Steps[this.Progress].move(this);           
            
        }
    } 
}
