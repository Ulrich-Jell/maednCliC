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
        public  Route ()
        {
            var XY = new List<Square>();
            XY.Add(new Square(8, 0, "S1"));
            XY.Add(new Square(8, 2, "()"));
            XY.Add(new Square(8, 4, "()"));
            XY.Add(new Square(8, 6, "()"));
            XY.Add(new Square(8, 8, "()"));
            XY.Add(new Square(6, 8, "()"));
            XY.Add(new Square(4, 8, "()"));
            XY.Add(new Square(2, 8, "()"));
            XY.Add(new Square(0, 8, "()"));
            XY.Add(new Square(0, 10, "()"));
            XY.Add(new Square(0, 12, "S2" ));
            XY.Add(new Square(2, 12 ,"()" ));
            XY.Add(new Square(4, 12, "()"));
            XY.Add(new Square(6, 12, "()"));
            XY.Add(new Square(8, 12 , "()"));
            XY.Add(new Square(8, 14, "()"));
            XY.Add(new Square(8, 16 , "()"));
            XY.Add(new Square(8, 18 , "()"));
            XY.Add(new Square(8, 20 , "()"));
            XY.Add(new Square(10, 20 , "()"));
            XY.Add(new Square(12, 20 , "S3"));
            XY.Add(new Square(12, 18 , "()"));
            XY.Add(new Square(12, 16 , "()"));
            XY.Add(new Square(12, 14 , "()"));
            XY.Add(new Square(12, 12 , "()"));
            XY.Add(new Square(14, 12 , "()"));
            XY.Add(new Square(16, 12 , "()"));
            XY.Add(new Square(18, 12, "()"));
            XY.Add(new Square(20, 12, "()"));
            XY.Add(new Square(20, 10, "()"));
            XY.Add(new Square(20, 8 , "S4"));
            XY.Add(new Square(18, 8, "()"));
            XY.Add(new Square(16, 8, "()"));
            XY.Add(new Square(14, 8, "()"));
            XY.Add(new Square(12, 8, "()"));
            XY.Add(new Square(12, 6, "()"));
            XY.Add(new Square(12, 4, "()"));
            XY.Add(new Square(12, 2, "()"));
            XY.Add(new Square(12, 0, "()"));
            XY.Add(new Square(10, 0, "()"));


            Steps = XY;
        }

        /*public List<Square> Squares = new List<Square>();
        public Route ()
        {
            var list = new List<Square>();
            list.Add(new Square(0, 12, "()"));
            list.Add(new HomeSquare(5, 9, "44"));
            list.Add(new StartSquare(5, 5, "77"));
        }*/
    }
}
