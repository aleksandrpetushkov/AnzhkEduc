using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace tst_02
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
			string[] stArr = { "111", "2222", "3333" };
			//string[] stArr1 = new string[5] 
			Array.Resize(ref stArr, 2);
			foreach(string stk in stArr)
				Console.Write(stk);
			Console.ReadKey();
			string st = string.Empty;
			string[] k = st.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
			DateTime.TryParseExact("202103010000", "yyyyMMddHHmm", CultureInfo.CurrentCulture
				, DateTimeStyles.AdjustToUniversal, out DateTime dt);
			dt = DateTime.UtcNow;
			Console.WriteLine(dt.ToUniversalTime());
			Console.WriteLine(dt.ToString() + "   " + dt.Millisecond);
			dt = DateTime.UtcNow;
			Console.WriteLine(dt.ToUniversalTime());
			Console.WriteLine(dt.ToString() + "   " + dt.Millisecond);
			dt = dt.AddMilliseconds(-dt.Millisecond);
			Console.WriteLine(dt.ToUniversalTime());
			Console.WriteLine(dt.ToString() + "   " + dt.Millisecond);

			//dt = DateTime.TryParseExact(str, frmt, CultureInfo.InvariantCulture
			//dt=DateTime.TryParseExact()
			// DateTime.TryParseExact("2021-03-01Z", CultureInfo.InvariantCulture
			// 	, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out DateTime dt0);
			Console.WriteLine(dt.ToUniversalTime());
			Console.WriteLine(dt.ToLocalTime());

			//DateTime.TryParse("2021-03-01Z", CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal, out dt);
			//DateTime.TryParseExact()
			Console.WriteLine(dt.ToUniversalTime());
			Console.WriteLine(dt);
			//dt = DateTime.TryParseExact(str, frmt, CultureInfo.InvariantCulture
			//dt=DateTime.TryParseExact()

			//dt = DateTime.TryParseExact("2021-03-01Z",  
			//CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out dt);
			Console.WriteLine(dt.ToUniversalTime());
			Console.WriteLine(dt.ToLocalTime());
			//return DateTime.TryParseExact(str, frmt, CultureInfo.InvariantCulture
			Console.ReadKey();
			try
			{
				try
				{
					throw new Exception("Exctp");
				}
				finally
				{
					Console.WriteLine("jfkdjfkdfjfk");
				}
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}