using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Board;
using maednCls.Tools;
using maednCls.Meeples;

namespace maednCls.Game
{
    public class SetUp
    {

        public ImportBoard board = new ImportBoard();
        public DrawBoard drawer = new DrawBoard();
        
        /*public MeepleRoute mr0 = new MeepleRoute(30);
        public MeepleRoute mr1 = new MeepleRoute(0);
        public MeepleRoute mr2 = new MeepleRoute(10);
        public MeepleRoute mr3 = new MeepleRoute(20);*/

        public List<Player> players = new List<Player>();


        public List<Meeple> allMeeples = new List<Meeple>();
        public static bool someoneHasWon = false;

        public SetUp()
        {

            Route route = new Route(board);
            ToolBelt toolBelt = new ToolBelt(board, route, drawer);
            Player zero = new Player(true, 1, "DAE504", 0, toolBelt);
            Player one = new Player(false, 2, "28B463", 10, toolBelt);
            Player two = new Player(false, 3, "E74C3C", 20, toolBelt);
            Player three = new Player(false, 4, "3498DB",  30, toolBelt);
            
            players.Add(zero); players.Add(one); players.Add(two); players.Add(three);

            allMeeples.Add(new Meeple(zero, "11", new HomeSquare(2, 3, "H1"), 0, "H1", toolBelt, 0));
            allMeeples.Add(new Meeple(zero, "12", new HomeSquare(2, 5, "H1"), 0, "H1", toolBelt));
            allMeeples.Add(new Meeple(zero, "13", new HomeSquare(4, 3, "H1"), 0, "H1", toolBelt));
            allMeeples.Add(new Meeple(zero, "14", new HomeSquare(4, 5, "H1"), 0, "H1", toolBelt));
            allMeeples.Add(new Meeple(one, "21", new HomeSquare(2, 15, "H2"), 1, "H2", toolBelt, 1));
            allMeeples.Add(new Meeple(one, "22", new HomeSquare(2, 17, "H2"), 0, "H2", toolBelt));
            allMeeples.Add(new Meeple(one, "23", new HomeSquare(4, 15, "H2"), 0, "H2", toolBelt));
            allMeeples.Add(new Meeple(one, "24", new HomeSquare(4, 17, "H2"), 0, "H2", toolBelt));
            allMeeples.Add(new Meeple(two, "31", new HomeSquare(16, 15, "H3"), 2, "H3", toolBelt, 2));
            allMeeples.Add(new Meeple(two, "32", new HomeSquare(16, 17, "H3"), 0, "H3", toolBelt));
            allMeeples.Add(new Meeple(two, "33", new HomeSquare(18, 15, "H3"), 0, "H3", toolBelt));
            allMeeples.Add(new Meeple(two, "34", new HomeSquare(18, 17, "H3"), 0, "H3", toolBelt));
            allMeeples.Add(new Meeple(three, "41", new HomeSquare(16, 3, "H4"), 3, "H4", toolBelt, 3));
            allMeeples.Add(new Meeple(three, "42", new HomeSquare(16, 5, "H4"), 0, "H4", toolBelt));
            allMeeples.Add(new Meeple(three, "43", new HomeSquare(18, 3, "H4"), 0, "H4", toolBelt));
            allMeeples.Add(new Meeple(three, "44", new HomeSquare(18, 5, "H4"), 0, "H4", toolBelt));



            drawer.Board = board;
            drawer.Players = players;            

            drawer.draw2();
       
            _ = new Move(players, allMeeples);


        }

    }
}
