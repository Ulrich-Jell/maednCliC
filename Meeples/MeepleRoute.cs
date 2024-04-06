using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maednCls.Game;

namespace maednCls.Meeples
{
    public class MeepleRoute
    {
        public List<List<int>> MRoute { get; set; }

        public MeepleRoute (int start)
        {
            /*var r = Route.CreateRoute();
            List<List<int>> mRoute = new List<List<int>>();

            for (int i = start; i < r.Count; i++)
                mRoute.Add(r[i]);
            for (int i = 0; i < start; i++)
                mRoute.Add(r[i]);
            MRoute = mRoute;     */       
            
        }
    }
}
