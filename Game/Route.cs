using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Board;

namespace maednCls.Game
{
    public class Route
    {
        public List<Square> Steps = new List<Square>();
        //public List<List<int>> Steps = new List<List<int>>();
        public  Route (ImportBoard board)
        {
            var xy = new List<Square>();
            xy.Add(new StartSquare(8, 0, "S1"));
            xy.Add(new Square(8, 2, "()"));
            xy.Add(new Square(8, 4, "()"));
            xy.Add(new Square(8, 6, "()"));
            xy.Add(new Square(8, 8, "()"));
            xy.Add(new Square(6, 8, "()"));
            xy.Add(new Square(4, 8, "()"));
            xy.Add(new Square(2, 8, "()"));
            xy.Add(new Square(0, 8, "()"));
            xy.Add(new Square(0, 10, "()"));
            xy.Add(new StartSquare(0, 12, "S2" ));
            xy.Add(new Square(2, 12 ,"()" ));
            xy.Add(new Square(4, 12, "()"));
            xy.Add(new Square(6, 12, "()"));
            xy.Add(new Square(8, 12 , "()"));
            xy.Add(new Square(8, 14, "()"));
            xy.Add(new Square(8, 16 , "()"));
            xy.Add(new Square(8, 18 , "()"));
            xy.Add(new Square(8, 20 , "()"));
            xy.Add(new Square(10, 20 , "()"));
            xy.Add(new StartSquare(12, 20 , "S3"));
            xy.Add(new Square(12, 18 , "()"));
            xy.Add(new Square(12, 16 , "()"));
            xy.Add(new Square(12, 14 , "vvv"));
            xy.Add(new Square(12, 12 , "()"));
            xy.Add(new Square(14, 12 , "()"));
            xy.Add(new Square(16, 12 , "()"));
            xy.Add(new Square(18, 12, "()"));
            xy.Add(new Square(20, 12, "()"));
            xy.Add(new Square(20, 10, "()"));
            xy.Add(new StartSquare(20, 8 , "S4"));
            xy.Add(new Square(18, 8, "()"));
            xy.Add(new Square(16, 8, "()"));
            xy.Add(new Square(14, 8, "()"));
            xy.Add(new Square(12, 8, "()"));
            xy.Add(new Square(12, 6, "()"));
            xy.Add(new Square(12, 4, "()"));
            xy.Add(new Square(12, 2, "()"));
            xy.Add(new Square(12, 0, "()"));
            xy.Add(new Square(10, 0, "()"));


            Steps = xy;
        }


    }

    

}

        