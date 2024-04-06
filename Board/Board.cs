using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Game;
using Microsoft.VisualBasic.FileIO;

namespace maednCls.Board
{
    public class Board
    {
        public List<List<string>> Coordinates { get; set; }
        public List<List<Square>> Squares { get; set; }

        public Board()
        {
            Coordinates = new List<List<string>>();
            Squares = new List<List<Square>>(); 
        }
        
        public void ImportBoard(List<Player> players)
        {            
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Board\board.csv");
            string sFilePath = Path.GetFullPath(sFile);


            using (TextFieldParser csvParser = new TextFieldParser(sFilePath))
            {
                csvParser.SetDelimiters(new string[] { ";" });              
                
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    List<String> boardString = new List<String>();
                    string[] fields = csvParser.ReadFields();
                    foreach (string field in fields)
                        boardString.Add(field);

                    Coordinates.Add(boardString);
                    
                }
            }
        }

        public void MoveMeeple()
        {

        }
    }
}
