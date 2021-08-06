using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace callBackTstCore
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			long ft, et, CrtInstr, ClMth, bt, ct, dt, CrtInstrAdd;
			List<int[]> lst = new(100000);
			//int k = 0;
			for(int i = 0; i < 100000; ++i)
			{
				int[] b = new int[10000];
				for(int j = 0; j < 10000; j++)
					b[j] = j;
				lst.Add(b);
			}
			List<int[]> kk = new(1000000);
			List<int[]> nw = new(1000000);
			List<Smfn> zz = new(1000000);
			Stopwatch sw = new();
			sw.Start();
			foreach(int[] elm in lst)
			{
				//Smfn s = new(elm, );
			}
			sw.Stop();
			CrtInstr = sw.ElapsedMilliseconds;
			//
			sw.Restart();
			foreach(int[] elm in lst)
			{
				Smfn s = new(elm, nw);
				zz.Add(s);
			}
			sw.Stop();
			CrtInstrAdd = sw.ElapsedMilliseconds;
			sw.Restart();
			foreach(Smfn smf in zz)
				smf.One();
			sw.Stop();
			ClMth = sw.ElapsedMilliseconds;
			//*/
			//* b test
			sw.Restart();
			foreach(int[] arr in lst)
				for(int q = 0; q < arr.Length; ++q)
					arr[q] = 10;
			sw.Stop();
			bt = sw.ElapsedMilliseconds;

			//* ct
			sw.Restart();
			foreach(int[] arr in lst)
				Arr(arr);
			sw.Stop();
			ct = sw.ElapsedMilliseconds;

			//* dt
			sw.Restart();
			foreach(int[] arr in lst)
				ArrD(arr, ArrInt);
			sw.Stop();
			dt = sw.ElapsedMilliseconds;

			//* de
			sw.Restart();
			foreach(int[] arr in lst)
				ArrE(arr, ArrD);
			sw.Stop();
			et = sw.ElapsedMilliseconds;
			/*/tw
			sw.Restart();
			foreach(int[] elm in lst)
			{
				Smf.One(elm, kk);
			}
			sw.Stop();
			ft = sw.ElapsedMilliseconds;
			//*/

			//out----
			Console.WriteLine(
				$"{nameof(CrtInstr)}:{CrtInstr}, {nameof(CrtInstrAdd)}:{CrtInstrAdd},  {nameof(bt)}:{bt},  {nameof(ClMth)}:{ClMth},  {nameof(ct)}:{ct},  {nameof(dt)}:{dt},  {nameof(et)}:{et}");
			Console.ReadKey();
		}

		//*
		private static void ArrM(int[] ark, Action<int[]> stmt)
		{
			stmt(ark);
		}

		//*/
		private static void Arr(int[] arr)
		{
			for(int q = 0; q < arr.Length; ++q)
				ArrInt(arr[q]);
		}

		//*
		private static void ArrE(int[] ark, Action<int[], Action<int>> stmt)
		{
			stmt(ark, ArrInt);
		}
		//*/

		private static void ArrD(int[] arr, Action<int> act)
		{
			for(int q = 0; q < arr.Length; ++q)
				act(arr[q]);
		}

		private static void ArrInt(int i)
		{
			i = 100;
		}
	}
}