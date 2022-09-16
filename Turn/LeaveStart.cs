using maednCls.Game;
using maednCls.Meeples;
using maednCls.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Turn
{
    public class LeaveStart
    {

        public LeaveStart (Player player)
        {
            var _ = new Dice();
            int dice = _.Roll(player);
            
            int selector = 0;

            foreach (Meeple m in player.Team)
            {
                if (m.Progress == 0)
                {
                    selector = player.Team.IndexOf(m);
                    break;
                }
            }
            
            if (player.Team[selector].CheckGoal(dice))
            {
                for (int i = 0; i < dice; i++)
                    player.Team[selector].Next();
            }
            else
                Console.WriteLine("Goal occupied by teammate. Choose a different meeple");
        }
    }
}
