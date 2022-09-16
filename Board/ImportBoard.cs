
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

        public ImportBoard()
        {
            Coordinate = new List<List<String>>();

            var path = @"C:\Users\ujell\source\repos\maednCls\Board\board.csv";
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.SetDelimiters(new string[] { ";" });

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    List<String> boardString = new List<String>();
                    string[] fields = csvParser.ReadFields();
                    foreach (string field in fields)
                        boardString.Add(field);

                    Coordinate.Add(boardString);

                }
            }
        }
    }
}