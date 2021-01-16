using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPers
{
    public abstract class People
    {
        public string Name { get;  set; }

        public string Last_name { get;  set; }

        public DateTime Birthday { get;  set; }
       

        public abstract void Print();
    }
}
