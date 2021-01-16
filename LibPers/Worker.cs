using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPers
{
    public class Worker : People
    {
        public uint Selary;
        public int Work_time;
        protected bool Illnes = false;
        public Dictionary<string, int> Works;
        public Worker(uint selary, string name, string last_name, DateTime dt, int work_time)
        {
            Selary = selary;
            Name = name;
            Last_name = last_name;
            Birthday = dt;
            Work_time = work_time;
            Works = new Dictionary<string, int>();
        }

        public Worker()
        {
        }

        public void CalcWorks()
        {
            int i=0;
            Console.WriteLine($"{Name} {Last_name} {Birthday} execute these works:");
            foreach(KeyValuePair<string, int> wrk in Works)
            {
                Console.WriteLine($"wokr: {wrk.Key} - hours: {wrk.Value}");
                i += wrk.Value;
            }
            Console.WriteLine($"Common number of working hours: {i}. Salary is: {i*Selary}");

        }

        public void ExecWorks(string v, int v1)
        {
            Works.Add(v, v1);
        } 
        public override void Print()
        {
            Console.WriteLine("Я работник");
        }

        bool Get_selary()
        {
            throw new NotImplementedException();
        }

        bool Work(int i)
        {
            throw new NotImplementedException();
        }
    }
}
