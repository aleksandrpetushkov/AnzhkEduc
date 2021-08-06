using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace _00
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string[] st;
			int x = 0;
			List<int> ls = new ();
			List<EnmInt> le = new List<EnmInt>();
			le.Add(EnmInt.One);
			le.Add(EnmInt.Two);
			le.Add(EnmInt.fork);
			Console.WriteLine(le.ToStringk());
			foreach(EnmInt enmInt in le)
			{
				Console.WriteLine(enmInt);
			}
			ls.Add(1);
			ls.Add(2);
			ls.Add(3);
			List<int> lk = new();
			lk.Add(5);
			lk.Add(6);
			var zz = lk.Intersect(ls);
			foreach(int i in zz)
			{
				Console.WriteLine(i);
			}
			
			while(x < 5)
			{
				Console.WriteLine("Введите цифры:");
				st = Console.ReadLine().Split(' ');
				int.TryParse(st[0], out int i);
				int.TryParse(st[1], out int r);
				int.TryParse(st[2], out int e);
				int c;
				c = Max(i, r, e);
				Console.WriteLine("Максимальное число:");
				Console.WriteLine(c);
				int s;
				s = Min(i, r, e);
				Console.WriteLine("Минимальное число:");
				Console.WriteLine(s);
				Console.ReadKey();
				++x;
			}
		}

		private static int Max(int k, int a, int s)
		{
			if(k > a)
			{
				if(k > s)
					return k;
				return s;
			}
			if(a > s)
				return a;
			return s;
		}

		private static int Min(int k, int a, int s)
		{
			if(k < a)
			{
				if(k < s)
					return k;
				return s;
			}
			if(a < s)
				return a;
			return s;
		}
	}
}