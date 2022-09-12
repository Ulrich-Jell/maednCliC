using maednCls.Board;
using maednCls.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Tools
{
    public class ToolBelt
    {
        public ImportBoard Board { get; set; }
        public Route Route { get; set; }
        public DrawBoard Drawer { get; set; }

        public ToolBelt(ImportBoard board, Route route, DrawBoard drawer)
        {
            Board = board;
            Route = route;
            Drawer = drawer;
        }
    }
}
