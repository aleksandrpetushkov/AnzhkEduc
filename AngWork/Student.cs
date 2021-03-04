using System;

namespace AngWork
{
	public delegate void Printing(string fotto);

	public class Student : AAlive
	{
		//public - идентификатор доступа
		public string Name;
		public string LastName;
		public int Age;

		//public Printing prt;
		public event Action<string, int> prt;
		public event Action Anniversary;

		//pb

		//Student - конструктор класса 
		//При объявлении конструктора с какими-либо параметрами - конструктор по умолчанию не доступен, если он требуется, его нужно явно создать
		//*
		public Student(string name, string last, int age)
		{
			Name = name;
			LastName = last;
			Age = age;
			Type = "Student";
		}

		public Student()
		{
		}

		public void live()
		{
			for(int i = Age; i < 100; ++i)
				if(i % 5 == 0)
					Anniversary.Invoke();
		}
		/*public Student(string name)
		{
		    Name = name;
		}
		public Student(string name, string lastN)
		{
		    Name = name;
		}
	
		
		public Student()
		{
	
		}*/

		//*
		// overide - говорит:
		// 1. что метод предопределяется из базового класса, в котором он помечен как "virtual"
		// 2. или реализуется из абстрактного-базового класса, данное действие является обязательным для абстрактного метода наследования абстрактного класса.
		public override void Print(int count)
		{
			prt?.Invoke($"Меня зовут: {Name} и меня печатают!!!", 12);

			//prt("Меня зовут: " + Name + "и меня печатают!!!");

			//(int i = 0; i < count; ++i) - параметры/условия цикла for, int i - 
			//int i = 0;
			for(int i = 0; i < count; ++i)
				//+ (plus) - конкатенирует строки (как бы "складывает") в результате мы получаем одну результирующую сконкатенированную строку
				// (как бы  сложенную) из маленьких строк и значений 
				Console.WriteLine("Имя: " + Name + ", " + "Фамилия: " + LastName + ", " + "Возраст: " + Age);
		}
		//*/

		public override void TEST()
		{
			base.TEST();
		}

		public void Print(int i, int k)
		{
		}

		public void Print(string count)
		{
			//int cnt; 
			if(int.TryParse(count, out int i))
				Print(i);
			else
				Console.WriteLine("Вы подали не число");
		}

		// static - поле/метод принадлежит классу, а не объекту и является общим для всех объектов, нельзя обратиться через объект, только через класс.

		public static void zzzz()
		{
			Console.WriteLine("zzzz");
		}

		/*
		public override string ToString()
		{
		    return Name+LastName+Age;
		}
	
		public string WhyYou()
		{
		    return "I'm People";
		}
	
		int Ialive.Age()
		{
		    return Age;
		}
		//*/
	}
}