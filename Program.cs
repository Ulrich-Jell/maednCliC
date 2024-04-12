using System;

using maednCls.Board;
using maednCls.Game;
using maednCls.Meeples;

namespace maednCls
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            Match match = new Match();
            match.SetUp();
            
            match.Start();


            
                
            
            //match.Start();
            //x.board.Coordinate[2][3] = "H1";





        }

        private static void Garfield_OnHealthChanged(object? sender, int e)         
        {             
            Console.WriteLine("OUCH!");             
            Console.WriteLine(e);         
        }
    }
}