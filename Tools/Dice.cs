using maednCls.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Tools
{
    public class Dice
    {
        public int Sides { get; set; }

        public Dice(int sides = 6)
        {
            Sides = sides;
        }

        public int Roll(Player player)
        {
            Random random = new Random();

            int roll = random.Next(1, Sides);
            roll = 2;

            Console.WriteLine(player.Name + " rolls a fixed " + roll);
            return roll;
        }
    }
}
