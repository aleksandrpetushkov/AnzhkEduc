using System;

namespace LibPers
{
	internal class Student: People
	{
		public uint Grant;
		public int Marks;

		public Student(string name, string last_name, DateTime dt, uint grant, int marks)
		{
			Name = name;
			Last_name = last_name;
			Birthday = dt;
			Grant = grant;
			Marks = marks;
		}

		public override void Print()
		{
			Console.WriteLine("Я студент");
		}
	}
}