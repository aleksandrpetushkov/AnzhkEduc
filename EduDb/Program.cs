using System;
using System.Collections.Generic;
using dbProvider;

namespace EduDb
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			PgProvider prvd = new PgProvider("192.168.0.11", "ang", "ang", "my_db", "tst_wh");
			List<string> i = prvd.execCmd(@"SELECT * from tch GROUP BY pk;");
			foreach(string st in i) Console.WriteLine(st);
		}
	}
}