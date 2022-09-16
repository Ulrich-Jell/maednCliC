using maednCls.Game;
using maednCls.Meeples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Turn
{
    public class CheckMoves
    {
        public Player Player { get; set; }


        public CheckMoves(Player player)
        {
            Player = player;

            List<string> atHome = new List<string>();
            List<string> done = new List<string>();
            List<Meeple> enRoute = new List<Meeple>();
            string onSquare0 = "";
            foreach (Meeple m in Player.Team)
            {              
                if (m.Progress == 0)
                    onSquare0 = m.Icon;
                else if (m.Progress < 0)
                    atHome.Add(m.Icon);
                else if (m.Progress == 2890)
                    done.Add(m.Icon);
                else
                    enRoute.Add(m);
            }            

            if (onSquare0 != "" && atHome.Count > 0)
            {
                var _ = new LeaveStart(Player);
            }
            else if (enRoute.Count == 0)
            {

                Console.WriteLine("leaveHome");
            }
            else if (enRoute.Count >= 1)
            {
                if (atHome.Count + done.Count == 3)
                {
                    var _ = new OnePossibleMove(enRoute[0]);
                }
                else
                {
                    var _ = new ChooseMeeple(enRoute);
                }
            }
            else
                Console.WriteLine("unexpected Situaton");         
        }
    }
}
