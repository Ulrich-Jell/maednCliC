using maednCls.Game;
using maednCls.Meeples;

namespace maednCls.Board
{
    public class HomeSquare : Square
    {
        public HomeSquare(int xPosition, int yPosition, string content) : base(xPosition, yPosition, content)
        {
        }

        public override void move(Meeple m)
        {
            List<int> result = new List<int>();
            Random random = new Random();
            result.Add(random.Next(1, 7));
            result.Add(random.Next(1, 7));
            result.Add(random.Next(1, 7));

            Console.WriteLine("You roll a {0}, a {1} and a {2}.", result[0], result[1], result[2]);
            Console.WriteLine("Applying Cheat...");
            result.Add(6);

            if (result.Contains(6))
            {
                m.Progress = 0 + m.Player.RouteCorrector;
                m.Player.Tools.Board.Coordinate[m.Home.XPosition][m.Home.YPosition] = m.LastContent;
                m.LastContent = m.Player.Tools.Route.Steps[m.Progress].Content;
                m.Player.Tools.Board.Coordinate[m.Player.Tools.Route.Steps[m.Progress].XPosition]
                    [m.Player.Tools.Route.Steps[m.Progress].YPosition] = m.No;

                m.Player.Tools.Drawer.draw();
                Console.WriteLine("Checking possible moves...");
            }

        }
    }
}
