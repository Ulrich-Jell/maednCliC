using maednCls.Board;
using maednCls.Tools;
using maednCls.Meeples;
using maednCls.Turn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace maednCls.Game
{
    public class SetUp
    {
        public SetUp()
        {
            //Questions:
            // Does Meeple need the Player-Property?
            
            
            ImportBoard board = new ImportBoard();            
            List<Player> players = new List<Player>();
            DrawBoard drawer = new DrawBoard(board, players);           

            players.Add(new Player("Player 1", "DAE504", 0));
            players.Add(new Player("Player 2", "28B463", 10));
            players.Add(new Player("Player 3", "E74C3C", 20));
            players.Add(new Player("Player 4", "3498DB", 30));
            

            Route route = new Route();

            players[0].Team.Add(new Meeple(players[0], "11", route, new Coordinate(3, 2), board, drawer, 2));
            players[0].Team.Add(new Meeple(players[0], "12", route, new Coordinate(5, 2), board, drawer, 0));
            players[0].Team.Add(new Meeple(players[0], "13", route, new Coordinate(3, 4), board, drawer));
            players[0].Team.Add(new Meeple(players[0], "14", route, new Coordinate(5, 4), board, drawer));
            players[1].Team.Add(new Meeple(players[1], "21", route, new Coordinate(15, 2), board, drawer));
            players[1].Team.Add(new Meeple(players[1], "22", route, new Coordinate(17, 2), board, drawer, 5));
            players[1].Team.Add(new Meeple(players[1], "23", route, new Coordinate(15, 4), board, drawer));
            players[1].Team.Add(new Meeple(players[1], "24", route, new Coordinate(17, 4), board, drawer));
            players[2].Team.Add(new Meeple(players[2], "31", route, new Coordinate(15, 16), board, drawer));
            players[2].Team.Add(new Meeple(players[2], "32", route, new Coordinate(17, 16), board, drawer));
            players[2].Team.Add(new Meeple(players[2], "33", route, new Coordinate(15, 18), board, drawer));
            players[2].Team.Add(new Meeple(players[2], "34", route, new Coordinate(17, 18), board, drawer));
            players[3].Team.Add(new Meeple(players[3], "41", route, new Coordinate(3, 16), board, drawer));
            players[3].Team.Add(new Meeple(players[3], "42", route, new Coordinate(5, 16), board, drawer));
            players[3].Team.Add(new Meeple(players[3], "43", route, new Coordinate(3, 18), board, drawer));
            players[3].Team.Add(new Meeple(players[3], "44", route, new Coordinate(5, 18), board, drawer));

            //players.Add(new Player("Admin", "FF00E8", 0));
            //players[4].Team.Add(new Meeple(players[4], "C#", route, new Coordinate(15, 2), board, drawer));

            board.Coordinate[2][17] = "H2";
            players[0].Team[1].LastContent = "()";

            drawer.draw();
            var _ = new CheckMoves(players[0]);
            Console.WriteLine("SetUp complete");
            
        }

    }
}
