using System.Collections.Generic;
using System.Linq;

namespace _00
{
	public static class Ext
	{
		public static string ToStringk(this List<EnmInt> prms)
		{
			string st = string.Empty;
			if(prms != null && prms.Any())
				foreach(EnmInt prm in prms)
					st += $"Param: {prm}  ";
			return st;
		}
	}
}