using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClt
{
	class Program
	{
		static void Main(string[] args)
		{
			HttpClient clt = new HttpClient();
			for(int k = 0; k < 21000; ++k)
			{
				var res = clt.GetAsync("http://127.0.0.1:1888").Result;
				ParcAsync(res, k);
				//Console.Write(reader.ReadLine());
				//			}
			}
			/*
			using 
			var k = new EnttSmpl("ffkdfjl", "jfkdsjfkasm");
			Console.WriteLine("kfjdskf");
			Console.ReadKey();
			//*/
		}

		/*
		private static async void parcAsync(HttpResponseMessage resResult)
		{
			throw new NotImplementedException();
		}
		//*/

		private static async void ParcAsync(HttpResponseMessage ss, int k)
		{
			//Task.Run(() => { Console.WriteLine("kfjsdkfjs"); });
			bool gz = false;
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			var srt = ss.Content.ReadAsStreamAsync().Result;
			await Task.Run(() =>
			{
				Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
				ss.Content.ReadAsStreamAsync();
				gz = GzipContext(ss.Content.Headers.ContentEncoding);
				Console.WriteLine(srt.Length);
				using StreamReader reader = new(gz ? new GZipStream(srt, CompressionMode.Decompress): srt, Encoding.UTF8);
				Console.WriteLine();
				//string st = reader.ReadToEnd();
				using StreamWriter f1 = new StreamWriter($@"d:\tmp_out\fs_{k}.txt", false, Encoding.UTF8);
				//using StreamWriter f2 = new StreamWriter(clt,)
				while(!reader.EndOfStream)
				{
					var sr = reader.ReadLine();
					//onsole.Write(sr);
					f1.WriteLine(sr);
					Thread.Sleep(100);
				}
				f1.Close();
				reader.Close();
				//res.Result.Dispose();
				//ss.Dispose();
			});
		}

		private static bool GzipContext(ICollection<string> encoding)
		{
			return encoding.Count > 0 && (encoding.Contains("gzip") || encoding.Contains("deflate"));
		}
	}
}