using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Board
{
    public class Route
    {
        public List<Coordinate> Path { get; set; }

        public Route()
        {
            List<Coordinate> path = new List<Coordinate>()
            {
                new Coordinate(0 , 8),
                new Coordinate(2 , 8),
                new Coordinate(4 , 8),
                new Coordinate(6 , 8),
                new Coordinate(8 , 8),
                new Coordinate(8 , 6),
                new Coordinate(8 , 4),
                new Coordinate(8 , 2),
                new Coordinate(8 , 0),
                new Coordinate(10 , 0),
                new Coordinate(12 , 0),
                new Coordinate(12 , 2),
                new Coordinate(12 , 4),
                new Coordinate(12 , 6),
                new Coordinate(12 , 8),
                new Coordinate(14 , 8),
                new Coordinate(16 , 8),
                new Coordinate(18 , 8),
                new Coordinate(20 , 8),
                new Coordinate(20 , 10),
                new Coordinate(20 , 12),
                new Coordinate(18 , 12),
                new Coordinate(16 , 12),
                new Coordinate(14 , 12),
                new Coordinate(12 , 12),
                new Coordinate(12 , 14),
                new Coordinate(12 , 16),
                new Coordinate(12 , 18),
                new Coordinate(12 , 20),
                new Coordinate(10 , 20),
                new Coordinate(8 , 20),
                new Coordinate(8 , 18),
                new Coordinate(8 , 16),
                new Coordinate(8 , 14),
                new Coordinate(8 , 12),
                new Coordinate(6 , 12),
                new Coordinate(4 , 12),
                new Coordinate(2 , 12),
                new Coordinate(0 , 12),
                new Coordinate(0 , 10),

            };

            Path = path;
        }




    }
}
