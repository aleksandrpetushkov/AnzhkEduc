using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngWork
{
    public abstract class AAlive
    {
        public string Type { get; set; } = "TypeNotSet";
        public abstract void Print(int coutn);

        public virtual void TEST()
        {
            Console.WriteLine($"Я виртуальный метод {typeof(AAlive)}");
        }

    }
}
