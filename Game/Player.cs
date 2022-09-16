using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Meeples;
using maednCls.Tools;

namespace maednCls.Game
{
    public class Player
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public List<Meeple> Team { get; set; } = new List<Meeple>();
        public int RouteFixer { get; set; }

        public Player (string name, string color, int routeFixer)
        {

            Name = name;
            Color = color;
            RouteFixer = routeFixer;
        }

        public void Next()
        {
            Console.WriteLine("not Implemented, yet");
        }
    }
}
