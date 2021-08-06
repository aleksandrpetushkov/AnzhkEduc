using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;

namespace callBackTst
{
	public class Smfn
	{
		private int[] any;
		private List<int[]> lst;

		public Smfn(int[] input, List<int[]> inptLst)
		{
			any = input;
			lst = inptLst;
			//One();
		}

		public Smfn()
		{
		}

		public void One()
		{
			lst.Add(any);
			Twho();
		}

		public void Twho()
		{
			lst.Add(any);
			Thre();
		}

		public void Thre()
		{
			lst.Add(any);
		}
	}

	public static class Smf
	{
		public static void One(int[] i, List<int[]> lst)
		{
			lst.Add(i);
			Twho(i, lst);
		}

		public static void OneCllBk(int[] i, List<int[]> lst)
		{
			lst.Add(i);
			TwhoCllBk(i, lst, Thre);
		}

		public static void Twho(int[] i, List<int[]> lst)
		{
			lst.Add(i);
			Thre(i, lst);
		}

		public static void TwhoCllBk(int[] i, List<int[]> lst, Action<int[], List<int[]>> dow)
		{
			lst.Add(i);
			dow(i, lst);
		}

		public static void Thre(int[] i, List<int[]> lst)
		{
			lst.Add(i);
		}
	}
}