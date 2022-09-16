using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Meeples
{
    public class ThrowOut
    {
        public Meeple Meeple { get; set; }
        public string Identifier { get; set; }

        public ThrowOut(Meeple meeple, string identifier)
        {
            Meeple = meeple;
            Identifier = identifier;

            int a = (int.Parse(Identifier[0].ToString()) - 1);
            int b = (int.Parse(Identifier[1].ToString()) - 1);

            Meeple enemy = meeple.Drawer.Players[a].Team[b];

            meeple.LastContent = enemy.LastContent;
            enemy.LastContent = String.Format("H{0}", a);
            enemy.Progress = -1860;
            enemy.X = enemy.Home.X;
            enemy.Y = enemy.Home.Y;
            meeple.Board.Coordinate[enemy.X][enemy.Y] = enemy.Icon;


        }
    }
}
