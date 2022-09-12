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
        public bool IsPlaying { get; set; }
        public int ID { get; set; }
        public string Color { get; set; }
        public int RouteCorrector { get; set; }
        public ToolBelt Tools { get; set; }



        public Player (bool isPlaying, int id, string color, int routeCorrector, ToolBelt tools)
        {
            IsPlaying = isPlaying;
            ID = id;
            Color = color;
            RouteCorrector = routeCorrector;
            Tools = tools;
        }
    }
}
