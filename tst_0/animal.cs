using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tst_0
{
    class Animal
    {
        public string Kind;
        public string Color;
        public int Age;

        public Animal(string kind, string color, int age)
        {
            Kind = kind;
            Color = color;
            Age = age;
        }

        public void Print(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine("Вид: " + Kind + "," + "Цвет: " + Color + "," + "Возраст: " + Age);
            }
        }























































    }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        //{
       // public string Color { get; set; } = "black";
        /*public string Name
        {
            get
            {
                return Name;
            }
            private set { }

        }
        int age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        
        //*
        public animal(string _clr, int _ag, string _name)
        {
            Color = _clr;
            age = _ag;
            Name = _name;

        }
        //*/
        ///public animal() { }


    //}
}
