using System;
using Extensions;

namespace tst_1
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Hellowzzzzz");
			var dt = DateTime.Now;
			Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
			//dt = new DateTime(dt.Ticks - (dt.Ticks % TimeSpan.TicksPerSecond));
			dt.Trim(TimeSpan.FromSeconds(1));
			Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
		}
	}
}