using maednCls.Game;
using maednCls.Meeples;

namespace maednCls.Board
{
    public class GoalSquare : Square
    {
        public GoalSquare(int xPosition, int yPosition, string content) : base(xPosition, yPosition, content)
        {
        }

        public Player owner { get; set; }

        public override void move(Meeple m)
        {
            Console.WriteLine("Simulate Move in Goal");
        }
    }
}
