using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Meeples;


namespace maednCls.Game
{
    public class Player
    {
        public bool IsPlaying { get; set; }
        public int ID { get; set; }
        public string Color { get; set; }
        public int RouteOffset { get; set; }

        public Player (bool isPlaying, int id, string color, int startPosition)
        {
            IsPlaying = isPlaying;
            ID = id;
            Color = color;
            RouteOffset = startPosition;
        }


    }
}