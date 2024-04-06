using maednCls.Meeples;

namespace maednCls.Board
{
    public class StartSquare : Square
    {
        public StartSquare(int xPosition, int yPosition, string content) : base(xPosition, yPosition, content)
        {
        }

        public override void move(Meeple m)
        {
            Console.WriteLine("Simulate move from Start for " + m.No);
            base.move(m);
        }
    }
}
