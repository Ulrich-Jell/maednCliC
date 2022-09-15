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
        public bool IsPlain { get; set; } = true;

        public Square (int xPosition, int yPosition, string content)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Content = content;
        }

        public Square(Square square)
        {
            XPosition = square.XPosition;
            YPosition = square.YPosition;
            Content = square.Content;
        }
        public virtual void move(Meeple m)
        {

        }
    }
}
