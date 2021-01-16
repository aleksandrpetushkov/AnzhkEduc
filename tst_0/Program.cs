using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
//using System.Web.Routing;

namespace tst_0
{
    class Program
    {
        static void Main(string[] args)
        /*{

            animal Ang = new animal("Black", 22, "Ang");
            animal Alk = new animal("White", 35, "Alk");
            animal Cat = new animal("Black", 22, "Cat");

            List<animal> List_anml = new List<animal>();
            List_anml.Add(Ang);
            List_anml.Add(Alk);
            List_anml.Add(Cat);
            



            Dictionary<string, animal> ds = new Dictionary<string, animal>();
            ds[Cat.Name] = Cat;
            ds[Ang.Name] = Ang;
            ds[Alk.Name] = Alk;


            Console.WriteLine(ds["Cat"]);
            Console.WriteLine(fin(List_anml));

            //fi(List_anml);



            /*
            Console.WriteLine(ang.ToString());
            Console.WriteLine(Alk.ToString());
            Console.WriteLine(Cat.ToString());
            //*/

        }


       /* static animal fin(List<animal> eltm)
        {
            for(int i = 0; i < eltm.Count; ++i)
            {
                if (eltm[i].Name == "Cat")
                {
                    return eltm[i];
                }
            }
            return null;
        }
        static void method() 
        {

            Console.WriteLine("Hello Angelica");
            Console.ReadKey();

            int i;
            if (0 > 1)
            {

            }
            else
            {

            }




            one o = new one(5, false);

            Console.WriteLine(o.oi);
            Console.WriteLine(o.ok);
            Console.ReadKey();
        }

        static int Calc(int i, int k)
        {
            int result;

            result = i + k;
            return result;

        }


        static int Calc2(ref int i, ref int k)
        {
            ++i;
            int result;

            result = i + k;
            return result;
        }
    }
}
