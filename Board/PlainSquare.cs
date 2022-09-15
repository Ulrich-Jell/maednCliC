using maednCls.Meeples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Board
{
    internal class PlainSquare : Square
    {
        public PlainSquare(int xPosition, int yPosition, string content) : base(xPosition, yPosition, content)
        {
        }

        public override void move(Meeple m)
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            Console.WriteLine("You roll a: " + dice);
            Console.WriteLine("Fixing a square in Square.cs");


            Square next = m.Tools.Route.Steps[m.Progress + dice];

            m.Tools.Board.Coordinate[next.XPosition][next.YPosition] = "23";


            if (m.Progress + dice > 39)
                Console.WriteLine("lalula");


            int t;
            if (m.Tools.Board.Coordinate[next.XPosition][next.YPosition][0] == m.No[0])
                Console.WriteLine("Occupied by teammate");
            else
            if (Int32.TryParse(m.Tools.Board.Coordinate[next.XPosition][next.YPosition], out t))
            {
                Console.WriteLine("Occupied by enemy");
            }
            else
            if (m.Tools.Board.Coordinate[next.XPosition][next.YPosition] == "()" ||
                Convert.ToString(m.Tools.Board.Coordinate[next.XPosition][next.YPosition][0]) == "S")
                Console.WriteLine("Square is empty");
            else
                Console.WriteLine("Something did not work");

            //m.Tools.Drawer.draw();

        }
    }
}
