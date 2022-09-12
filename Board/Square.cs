using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Game;
using maednCls.Meeples;

namespace maednCls.Board
{
    public class Square
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string Content { get; set; }

        public Square (int xPosition, int yPosition, string content)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Content = content;
        }

        public virtual void move(Meeple m)
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            Console.WriteLine("You roll a: " + dice);
            Console.WriteLine("Fixing dice and a square in Square.cs");
            
            dice = 3;
            m.Tools.Board.Coordinate[12][14] = "39";
            Console.WriteLine("");

            if (m.Progress + dice > 39)
                Console.WriteLine("lalula");

            

            if (m.Tools.Board.Coordinate[m.Tools.Route.Steps[m.Progress + dice].XPosition]
                [m.Tools.Route.Steps[m.Progress + dice].YPosition][0] == m.No[0])
                Console.WriteLine("Occupied by teammate");
            else
                Console.WriteLine("Something did not work");

            Console.WriteLine();
        }
    }
}
