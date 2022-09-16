using maednCls.Meeples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maednCls.Turn
{
    public class ChooseMeeple
    {
        public List<Meeple> meeples { get; set; }

        public ChooseMeeple(List<Meeple> meeples)
        {
            this.meeples = meeples;
        }
    }
}
