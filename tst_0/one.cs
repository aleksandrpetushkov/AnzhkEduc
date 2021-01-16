using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tst_0
{
    class one
    {
        public one(int i, bool b)
        {
            if (b)
            {
                oi = i;
            }
            else if (!b)
            {
                ok = i;
            }
        }


        public int oi = 0;
        public int ok = 0;

    }
}
