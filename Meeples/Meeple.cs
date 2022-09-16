using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Game;
using maednCls.Board;
using maednCls.Tools;

namespace maednCls.Meeples
{
    public class Meeple
    {
        public Player Player { get; set; }
        public string Icon { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Route Route { get; set; }
        public int Progress { get; set; }
        public Coordinate Home {get; set;}
        public ImportBoard Board { get; set; }
        public string LastContent { get; set; } = "S1";
        public DrawBoard Drawer { get; set; }
        public Meeple(Player player, string icon, Route route, Coordinate home, ImportBoard board, DrawBoard drawer, int progress = -1860)
        {
            Player = player;
            Icon = icon;
            X = home.X;
            Y = home.Y;
            Progress = progress + Player.RouteFixer;
            Home = home;
            Route = route;
            Board = board;
            Drawer = drawer;

            if (Progress >= 0)
            {
                X = Route.Path[Progress].X;
                Y = Route.Path[Progress].Y;
            }
            Board.Coordinate[X][Y] = Icon;
        }

        public void Next ()
        {           
            Board.Coordinate[X][Y] = LastContent;
            Progress += 1;
            X = Route.Path[Progress].X;
            Y = Route.Path[Progress].Y;
            if (!(Board.Coordinate[Route.Path[Progress].X][Route.Path[Progress].Y][0] == Convert.ToChar("S") ||
                Board.Coordinate[Route.Path[Progress].X][Route.Path[Progress].Y][0] == Convert.ToChar("(")))
            { var _ = new ThrowOut(this, Board.Coordinate[Route.Path[Progress].X][Route.Path[Progress].Y]);}
            LastContent = Board.Coordinate[X][Y];
            Board.Coordinate[X][Y] = Icon;
            Console.ReadKey();
            Drawer.draw();
        }

        public bool CheckGoal(int dice)
        {
            bool goalFree = false;
            int check = Progress + dice;

            if (Board.Coordinate[Route.Path[check].X][Route.Path[check].Y][0] != Icon[0])
            {
                goalFree = true;
            }
            return goalFree;
        }
        
    }
}
