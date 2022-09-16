using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Board
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Content { get; set; } = "()";
        public ImportBoard Board { get; set; }

        public Coordinate (int x, int y)
        {
            X = y;
            Y = x;
        }
    }
}
