using System.ComponentModel;
using maednCls.Board;

namespace maednCls.Helper
{
    public class Constants
    {
        public static List<Square> Route = new()
        {
            new Square(8, 0, "S1"),
            new Square(8, 2, "()"),
            new Square(8, 4, "()"),
            new Square(8, 6, "()"),
            new Square(8, 8, "()"),
            new Square(6, 8, "()"),
            new Square(4, 8, "()"),
            new Square(2, 8, "()"),
            new Square(0, 8, "()"),
            new Square(0, 10, "()"),
            new Square(0, 12, "S2" ),
            new Square(2, 12 ,"()" ),
            new Square(4, 12, "()"),
            new Square(6, 12, "()"),
            new Square(8, 12 , "()"),
            new Square(8, 14, "()"),
            new Square(8, 16 , "()"),
            new Square(8, 18 , "()"),
            new Square(8, 20 , "()"),
            new Square(10, 20 , "()"),
            new Square(12, 20 , "S3"),
            new Square(12, 18 , "()"),
            new Square(12, 16 , "()"),
            new Square(12, 14 , "()"),
            new Square(12, 12 , "()"),
            new Square(14, 12 , "()"),
            new Square(16, 12 , "()"),
            new Square(18, 12, "()"),
            new Square(20, 12, "()"),
            new Square(20, 10, "()"),
            new Square(20, 8 , "S4"),
            new Square(18, 8, "()"),
            new Square(16, 8, "()"),
            new Square(14, 8, "()"),
            new Square(12, 8, "()"),
            new Square(12, 6, "()"),
            new Square(12, 4, "()"),
            new Square(12, 2, "()"),
            new Square(12, 0, "()"),
            new Square(10, 0, "()"),
        };

        public static List<Square> OutPlayer1 = new()
        {
            new Square(2,3,"11"),
            new Square(2,5,"12"),
            new Square(4,3,"13"),
            new Square(4,5,"14")
        };

        public static List<Square> OutPlayer2 = new()
        {
            new Square(2,15,"21"),
            new Square(2,17,"22"),
            new Square(4,15,"23"),
            new Square(4,17,"24")
        };

        public static List<Square> OutPlayer3 = new()
        {
            new Square(16,15,"41"),
            new Square(16,17,"42"),
            new Square(18,15,"43"),
            new Square(18,17,"44")
        };

        public static List<Square> OutPlayer4 = new()
        {
            new Square(16,3,"31"),
            new Square(16,5,"32"),
            new Square(18,3,"33"),
            new Square(18,5,"34")
        };

        public static List<Square> AllOuts = new()
        {
            OutPlayer1[0],
            OutPlayer1[1],
            OutPlayer1[2],
            OutPlayer1[3],
            OutPlayer2[0],
            OutPlayer2[1],
            OutPlayer2[2],
            OutPlayer2[3],
            OutPlayer3[0],
            OutPlayer3[1],
            OutPlayer3[2],
            OutPlayer3[3],
            OutPlayer4[0],
            OutPlayer4[1],
            OutPlayer4[2],
            OutPlayer4[3],
        };

        public static List<Square> HomePlayer1 = new()
        {
            new Square(10, 2, "H1"),
            new Square(10, 4, "H1"),
            new Square(10, 6, "H1"),
            new Square(10, 8, "H1")
        };

        public static List<Square> HomePlayer2 = new()
        {
            new Square(2, 10, "H2"),
            new Square(4, 10, "H2"),
            new Square(6, 10, "H2"),
            new Square(8, 10, "H2")
        };

        public static List<Square> HomePlayer3 = new()
        {
            new Square(10, 12, "H3"),
            new Square(10, 14, "H3"),
            new Square(10, 16, "H3"),
            new Square(10, 18, "H3")
        };

        public static List<Square> HomePlayer4 = new()
        {
            new Square(12, 10, "H4"),
            new Square(14, 10, "H4"),
            new Square(16, 10, "H4"),
            new Square(18, 10, "H4")
        };
    }

    public enum Status 
    {
        outArea,
        enRoute,
        home,
        finished
    }

}