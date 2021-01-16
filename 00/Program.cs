using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] st;
            int x = 0;

            while (x < 5)
            {
               
                Console.WriteLine("Введите цифры:");
                st = Console.ReadLine().Split(' ');
                int.TryParse(st[0], out int i);
                int.TryParse(st[1], out int r);
                int.TryParse(st[2], out int e);

                

                int c;
                c = Max(i, r, e);
                Console.WriteLine("Максимальное число:");
                Console.WriteLine(c);

                int s;
                s = Min(i, r, e);
                Console.WriteLine("Минимальное число:");
                Console.WriteLine(s);






                Console.ReadKey(); 
                ++x;
            }
        }
        static int Max(int k, int a, int s)
        {
            if (k > a)
            {
                if (k > s)
                {
                    return k;
                }
                else
                {
                    return s;
                }
            }
            else if (a > s)
            {
                return a;
            }
            else
            {
                return s;
            }
        }

        static int Min (int k, int a, int s)
        {
            if (k < a)
            {
                if (k < s)
                {
                    return k;
                }
                else
                {
                    return s;
                }
            }
            else if (a < s)
            {
                return a;
            }
            else
            {
                return s;
            }
        }
    }
}
