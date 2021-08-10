using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhLib
{
	static class Exten
	{
		public static string PrDic<Tp, Tk>(this Dictionary<Tp, Tk> dic)
		{
			string st = string.Empty;
			foreach(var v in dic)
			{
				st += $"Key:{v.Key}, Val:{v.Value}\n";
			}
			return st;
		}


	}
}