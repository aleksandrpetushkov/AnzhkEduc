using System;
using dbProvider;

namespace EduDb
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			var prvd = new PgProvider("192.168.0.11", "ang", "ang", "my_db", "tst_wh");
			var i = prvd.execCmd(@"SELECT * from tch GROUP BY pk;");
			foreach(var st in i) Console.WriteLine(st);
		}
	}
}