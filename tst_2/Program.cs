using System;
using System.Threading;
using System.Threading.Tasks;

namespace tst_2
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string st = "";
			if(st == string.Empty)
			{
				Console.WriteLine();
			}
			Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}  {Task.CurrentId}");
			WrtCharA('A');
			WrtChar('C');
		}
		protected static async void WrtCharA(char c)
		{
			Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}  {Task.CurrentId}");
			var t = Task.Run(() => WrtChar(c));
			Thread.Sleep(300);
			await t;
			Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}  {Task.CurrentId}");
		}
		private static char WrtChar(char c)
		{
			for(int i = 0; i < 10; ++i)
			{
				Console.Write($"{c} ");
				Thread.Sleep(100);
				}
			return c;
		}
	}
}