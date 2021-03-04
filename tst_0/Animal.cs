using System;

namespace tst_0
{
	internal class Animal
	{
		public int Age;
		public string Color;
		public string Type;

		public Animal(string color, int age, string type, string name)
		{
			Type = type;
			Color = color;
			Age = age;
			Name = name;
		}

		public string Name { get; }

		public void Print(int count)
		{
			for(int i = 0; i < count; ++i) Console.WriteLine("Вид: " + Type + "," + "Цвет: " + Color + "," + "Возраст: " + Age);
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