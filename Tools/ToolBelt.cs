﻿using maednCls.Board;
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
        public Board.Board Board { get; set; }


        public ToolBelt(Board.Board board)
        {
            Board = board;
        }
    }
}
