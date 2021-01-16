using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngWork;
using System.IO;
using System.Windows.Forms;

namespace lesson2
{

    /// <summary>
    /// Plan:
    /// 0. open/create source for load data!
    /// 1. Load data from source.!
    /// 1.1 Prepare loaded data for create objects!
    /// 2. Create objects from load data (p.1.1)!
    /// 3. объявить переменную коллекцию (list dictionary)
    /// 3.1 Put objects (p.2) to other collection
    /// 4. Print out object from collection to console
    /// </summary>
    class Program
    {
        public delegate void sttt(string st);
        
        static void Main(string[] args)
        {
            StreamReader ps = new StreamReader(@"C:\Users\Sth\Desktop\peoples.txt");
            Student lol;            
            List<Student> ls = new List<Student>();
            Dictionary<string, Student> dc = new Dictionary<string, Student>();
            
            


            while (!ps.EndOfStream)
            {
                //Console.WriteLine(ps.ReadLine().Trim(' '));
                string st_reader = string.Empty;
                try
                {
                    string[] st_mass;
                    st_reader = ps.ReadLine();
                    st_mass = st_reader.Split(',');                    
                    
                    /*
                    if (!(st_mass?.Count() >= 3))
                    {
                        Console.WriteLine("Мала строкав");
                        break;
                    }
                    /*/
                    //Console.WriteLine(st_mass[0]);
                    //Console.WriteLine("Анжелика");

                    lol = new Student(st_mass[0], st_mass[1], Convert.ToInt32(st_mass[2]));
                    lol.prt += Валя;
                    lol.prt += Галя;

                    //lol.Print("1");
                    ls.Add(lol);
                    dc.Add(lol.Name, lol);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Мы пытались загрузизить строку {st_reader} и чота мы эксепшн славили вот его мессадж: {e.Message}");

                }
                finally
                {
                    /*
                    Console.WriteLine("я блок финели работаю всегда.\nБыл ли эксепш - мне пофег");
                    Console.WriteLine($"Мы пытались загрузить какуюто строку: " + st_reader);
                    //*/
                }


            }

            /*
            Console.WriteLine();
            for (int i = 0; i < ls.Count; ++i)
            {
                ls[i].Print(1);
            }

            Console.WriteLine("\nWorking \"foreach\"");
            foreach (KeyValuePair<string, Student> st in dc)
            {
                st.Value.Print(1);
                st.Key.Split();
            }
            //*/

            Console.WriteLine();
            for (int i = 0; i < ls.Count; ++i)
            {
                ls[i].Print(1);
                ls[i].prt -= Валя;
                ls[i].prt -= Галя;
                ls[i].prt += Коля;
            }




            Console.WriteLine($"\r\n\r\nВыводим студентов после отписки...");
            for (int i = 0; i < ls.Count; ++i)
            {
                ls[i].Print(1);
               
            }




            void Валя(string st, int i)
            {
                Console.WriteLine($"Я Валя и я получила сообщеие студента: {st}");
            }


            void Галя(string st, int i)
            {
                Console.WriteLine($"Я Галя и я получила сообщеие студента: {st}");
            }


            void Коля(string st, int i)
            {
                Console.WriteLine($"Я Коля и я получила сообщеие студента: {st}");
            }




















            Console.ReadKey();
        }
        public static void Print (string st)
        {
            Console.WriteLine(st);
        }












    }
}
