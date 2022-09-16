using maednCls.Meeples;
using maednCls.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Turn
{
    public class OnePossibleMove
    {
        public Meeple Meeple { get; set; }
        public Dice Dice { get; set; }

        public OnePossibleMove (Meeple meeple)
        {
            Meeple = meeple;
            Dice = new Dice ();
            int dice = Dice.Roll(Meeple.Player);

            if (Meeple.CheckGoal(dice))
            {
                for (int i = 0; i < dice; i++)
                {
                    Meeple.Next();
                }
            }
            else
                Meeple.Player.Next();
                
                
        }
    }
}
