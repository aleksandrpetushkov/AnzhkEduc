using System;

namespace AngWork
{
	public class Animal : AAlive
	{
		public string Kind;
		public string Color;
		public int Age;

		public Animal(string kind, string color, int age)
		{
			Kind = kind;
			Color = color;
			Age = age;
			Type = "Animal";
		}

		public override void Print(int count)
		{
			for(var i = 0; i < count; ++i) Console.WriteLine("Вид: " + Kind + "," + "Цвет: " + Color + "," + "Возраст: " + Age);
		}

		/*
		   int Ialive.Age()
		   {
		       return Age;
		   }
   
		   string Ialive.WhyYou()
		   {
		       return "I'm Aninam";
		   }
		   */
	}
}