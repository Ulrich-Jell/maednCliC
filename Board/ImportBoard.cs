using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace maednCls.Board
{
    public class ImportBoard
    {
        public List<List<string>> Coordinate { get; set; }
        public List<List<Square>> Square { get; set; }
        
        public ImportBoard()
        { 
            Coordinate = new List<List<String>>();
            Square = new List<List<Square>>();

            var path = @"C:\Users\ujell\source\repos\maednCls\Board\board.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(new string[] { ";" });              
                
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    List<String> boardString = new List<String>();
                    List<Square> squareList = new List<Square>();
                    string[] fields = csvParser.ReadFields();
                    int x = 0;
                    foreach (string field in fields)
                    {
                        int y = 0;
                        if (Convert.ToString(field[0]) == "S")
                            squareList.Add(new StartSquare(x, y, field));
                        else
                            squareList.Add(new Square(x, y, field));
                        boardString.Add(field);

                    }

                    Coordinate.Add(boardString);
                    Square.Add(squareList);                   
                    
                }
            }
        }
    }
}
