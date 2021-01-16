using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibPers;

namespace Wrk
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dobro Pojalovat v soft ucheta rabot personala!");
            Worker wrk;
            string[] st;
            Console.WriteLine("Enter name worker and selary:");



            while (true)
            {
                st = Console.ReadLine().Split(' ');

                if (st.Length < 3 || !int.TryParse(st[2], out int i))
                {
                    Console.WriteLine("Povtorite vvod");
                    continue;

                }
                break;
            }
            DateTime dtbrd = new DateTime(int.Parse(st[3]), int.Parse(st[4]), int.Parse(st[5]));
            wrk = new Worker(uint.Parse(st[2]), st[0], st[1], dtbrd, 0);
            


            while (true)
            {
                Console.Write("--------------------------\nMenu:\n1. Execute work.\n2. Calc work and exit.\nEnter why do you want: ");
                string s = Console.ReadLine();
                int m = int.Parse(s);
                switch (m)
                {
                    case 1:
                        Console.Write("Enter type work and hours: ");
                        string wrk_hours = Console.ReadLine();
                        string[] ms_wrk_hours = wrk_hours.Split(' ');
                        wrk.ExecWorks(ms_wrk_hours[0], int.Parse(ms_wrk_hours[1]));
                        break;
                    case 2:
                        wrk.CalcWorks();
                        break;
                    default:
                        {
                            break;
                        }
                }




            }

            Console.ReadKey();
        }
    }

}
