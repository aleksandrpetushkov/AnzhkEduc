using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HttpClt;

namespace httpSrv
{
	class Program
	{
		static byte[] st;
		static JsonSerializerSettings DfltSttngs = new JsonSerializerSettings { Formatting = Formatting.Indented };
		static JsonSerializer seril = JsonSerializer.CreateDefault(DfltSttngs);

		static void Main(string[] args)
		{
			HttpListener lst = new HttpListener();
			lst.Prefixes.Add("http://127.0.0.1:1888/");
			lst.Start();
			while(true)
			{
				//Task<HttpListenerContext> ctnxA;// = lst.GetContext();
				var context = lst.GetContext();
				string[] stArr = context.Request.Url.AbsolutePath.Split("/", StringSplitOptions.RemoveEmptyEntries);
				if(stArr.Length == 1)
				{
					if(stArr[0] == "favicon.ico")
					{
						using(HttpListenerResponse rp = context.Response)
						{
							context.Response.StatusCode = 404;
							context.Response.Close();
						}
					}
					continue;
				}
				//wrtFile(context);
				Jsns(context);
			}
		}

		private static void wrtFile(HttpListenerContext context)
		{
			FileStream fst = File.Open(@"d:\_del\Kingroot.apk", FileMode.Open);
			//StreamReader str = new StreamReader(@"d:\_del\Kingroot.apk");
			context.Response.ContentLength64 = fst.Length;
			//context.//Response.SendChunked = false;
			context.Response.ContentType = MediaTypeNames.Application.Octet;
			context.Response.AddHeader("Content-disposition", "attachment; filename=Kingroot.apk");
			context.Response.AddHeader("Access-Control-Allow-Origin", "*");
			context.Response.StatusCode = 200;
			fst.CopyTo(context.Response.OutputStream);
			context.Response.OutputStream.Close();
		}

		static async void Jsns(HttpListenerContext cntxt)
		{
			bool gz = true;
			//cntxt.Response.Close();
			//var strWrt = ;
			cntxt.Response.StatusCode = 200;
			cntxt.Response.AddHeader("Content-type", "application/json; charset=utf-8");
			cntxt.Response.AddHeader("Access-Control-Allow-Origin", "*");
			cntxt.Response.AddHeader("Content-Encoding", "gzip");
			using var memstr = new MemoryStream();
			using var memCopy = new MemoryStream();
			using var memCopyfrmArr = new MemoryStream();
			using var kk =
				new JsonTextWriter(new StreamWriter(new GZipStream(memstr, CompressionLevel.Optimal, false), Encoding.UTF8))
				{
					Formatting = seril.Formatting
				};
			kk.WriteStartArray();
			for(ushort i = 0; i < 10000; ++i)
			{
				seril.Serialize(kk, new EnttSmpl(i, "Ote" + i, "ВТОРОЙ_ПОШЁЛ" + i));
			}
			kk.WriteEndArray();
			kk.Flush();
			st = memstr.ToArray();
			StreamReader streamReader;
			Stream memCopy2;
			using(memCopy2 = new GZipStream(new MemoryStream(st), CompressionMode.Decompress))
			{
				using(streamReader = new StreamReader(memCopy2, Encoding.UTF8))
				{
					while(!streamReader.EndOfStream)
					{
						//Console.WriteLine("22222222222222");
						Console.WriteLine(streamReader.ReadLine());
					}
				}
			}
			cntxt.Response.OutputStream.Write(st);
			cntxt.Response.OutputStream.Close();
			//memCopy2.CopyTo(cntxt.Response.OutputStream);
			//byte[] che = memCopy.ToArray();

			//memstr.CopyTo(cntxt.Response.OutputStream);

			//	st = 

			//cntxt.Response.OutputStream.Write(st, 0, st.Length);
			/*
			if(gz)
				cntxt.Response.AddHeader("Content-Encoding", "gzip");
			var writerJsn =
				new JsonTextWriter(new StreamWriter(
					gz ? new GZipStream(cntxt.Response.OutputStream, CompressionLevel.Optimal, false): cntxt.Response.OutputStream
					, Encoding.UTF8)) { Formatting = seril.Formatting };
			
			//*/

			//cntxt.Response.OutputStream.writerJsn.WriteEndArray();

			//writerJsn.Close();

			//tw.Close();
			//strm.Close();
			//cntxt.Response.OutputStream.Close();
			//cntxt.Response.OutputStream.Close();
			cntxt.Response.Close();
			int z = 0;
		}

		static byte[] DeCompres(byte[] deCmprs)
		{
			using var MemOut = new MemoryStream();
			using var memstrCmprs = new MemoryStream(deCmprs);
			using var BigPack = new GZipStream(memstrCmprs, CompressionMode.Decompress);
			BigPack.CopyTo(MemOut);
			byte[] DeCmprs = MemOut.ToArray();
			return DeCmprs;
		}

		//*
		static byte[] Compres(byte[] cmprs)
		{
			//var bytes = Encoding.UTF8.GetBytes(str);
			using(var msi = new MemoryStream(cmprs))
				using(var mso = new MemoryStream())
				{
					using(var gs = new GZipStream(mso, CompressionMode.Compress))
					{
						msi.CopyTo(gs);
						//CopyTo(msi, gs);
					}
					return mso.ToArray();
				}
		}
		//*/
	}
}