using System;
using System.Collections.Generic;

namespace AngWork
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			//*
			//Создаем объекты типа student
			Student Ang = new Student("Анжелика", "Захарова", 22);
			AAlive kk = new Student("Test", "Test", 0);
			kk.Print(1);
			Student Alex = new Student("Александр", "Петушков", 25);
			Student Svet = new Student("Светлана", "Козина Привет ", 22);

			//Ang.Print("");
			List<Student> People = new List<Student>(100);
			People.Add(Ang);
			People.Add(Alex);
			People.Add(Svet);
			People.Add(new Student("Сергей", "XXX", 30));
			Console.WriteLine("Working \"for\"");
			for(int i = 0; i < People.Count; ++i) People[i].Print(1);
			Console.WriteLine("\nWorking \"foreach\"");
			foreach(AAlive st in People) st.Print(1);
			Dictionary<string, AAlive> DP = new Dictionary<string, AAlive>();
			DP.Add(Ang.Name, Ang);
			DP.Add(Alex.Name, Alex);
			DP.Add(Svet.Name, Svet);
			Console.WriteLine("\n\tWorking \"for\"");
			for(int a = 0; a < DP.Count; ++a) People[a].Print(1);
			foreach(var VARIABLE in Alex)
			{
			}
			Console.WriteLine("\nWorking \"foreach\"");
			foreach(KeyValuePair<string, AAlive> st in DP) st.Value.Print(1);
			Animal Cat = new Animal("Цыся", "Черный", 10);
			Animal Dog = new Animal("Даня", "Золотой", 6);
			Animal Bird = new Animal("Кеша", "Пурпурный", 4);
			AAlive aa = new Animal("Koooo6osh", "Ble", 1_000_0_0_0_00);
			List<AAlive> Ani = new List<AAlive>();
			Ani.Add(Cat);
			Ani.Add(Dog);
			Ani.Add(Bird);
			Ani.Add(aa);
			Console.WriteLine("Working \"for\"");
			for(int i = 0; i < Ani.Count; ++i) (Ani[i] as Animal).Print(1);

			//AAlive aa = new Animal("Koooo6osh", "Ble", 1_000_000);

			//*/
			List<AAlive> lalive = new List<AAlive>();
			lalive.Add(Ang);
			lalive.Add(Alex);
			lalive.Add(Svet);
			lalive.Add(People[3]);
			lalive.Add(Cat);
			lalive.Add(Dog);
			lalive.Add(Bird);
			foreach(AAlive I in lalive) Console.WriteLine(I.Type);
			Console.WriteLine("\n\n\nPress any key...");
			Console.ReadKey();
		}
	}
}