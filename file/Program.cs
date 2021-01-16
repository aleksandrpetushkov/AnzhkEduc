using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file
{ 
    
/// <summary>
/// Plan:
/// 1. Load data from file.
/// 2. Create proper objects
/// 3. Put objects (p.2) to other collection
/// 4. Print out object from collection to console
/// </summary>
    class Program
    {
        private const string V = "filesdd.txt";

        static void Main(string[] args)
        {

            StreamWriter f0 = new StreamWriter(File.Open("file.txt", FileMode.OpenOrCreate), Encoding.UTF8);
            StreamWriter f1 = new StreamWriter("fs.txt", false, Encoding.UTF8);
            //f0.AutoFlush = true;
            //f0.WriteLine("Angelika, Анжелика");
            f0.Dispose();
            
            //*
            using (f1)
            {
                f1.WriteLine("2Angelika, Анжелика");
            }
            //*/

            //StreamReader fr = new StreamReader("fs.txt", Encoding.UTF8);

            //Console.WriteLine(fr.ReadLine());



            Console.ReadKey();

        }
    }
}
