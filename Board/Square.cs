using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Game;
using maednCls.Meeples;

namespace maednCls.Board
{
    public class Square
    {
        public int Row { get; set; }
        public int Spot { get; set; }
        public string DefaultContent { get; set; }
        public string CurrentContent {get; set;}

        public Meeple Occupant {get; set;}
        
        // private Meeple _occupant {get; set;}
        // public Meeple Occupant 
        // {
        //     get => this.Occupant; 
        //     set
        //     {
        //         this.Occupant = value;
        //         this.OnOccupantChanged?.Invoke(this, this._occupant);
        //     }
        // }

        // public event EventHandler<Meeple> OnOccupantChanged;

        public Square (int row, int spot, string defaultContent)
        {
            Row = row;
            Spot = spot;
            DefaultContent = defaultContent;
            CurrentContent = defaultContent;
            Occupant = new Meeple();
        }


    }
}
