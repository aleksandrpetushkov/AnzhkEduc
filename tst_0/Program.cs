using System;
using System.Collections.Generic;

//using System.Web.Routing;

namespace tst_0
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var Ang = new Animal("Black", 22, "Ang", "Angelica");
			var Alk = new Animal("White", 35, "Volk", "Kuzmich");
			var Cat = new Animal("Black", 22, "Cat", "Cisic");
			var List_anml = new List<Animal>();
			List_anml.Add(Ang);
			List_anml.Add(Alk);
			List_anml.Add(Cat);
			var ds = new Dictionary<string, Animal>();
			ds[Cat.Name] = Cat;
			ds[Ang.Name] = Ang;
			ds[Alk.Name] = Alk;
			Console.WriteLine(ds["Cisic"]);
			//Console.WriteLine(fin(List_anml));

			//fi(List_anml);
			/*
			Console.WriteLine(ang.ToString());
			Console.WriteLine(Alk.ToString());
			Console.WriteLine(Cat.ToString());
			//*/
		}

		/* static animal fin(List<animal> eltm)
		 {
		     for(int i = 0; i < eltm.Count; ++i)
		     {
		         if (eltm[i].Name == "Cat")
		         {
		             return eltm[i];
		         }
		     }
		     return null;
		 }
		 static void method() 
		 {
 
		     Console.WriteLine("Hello Angelica");
		     Console.ReadKey();
 
		     int i;
		     if (0 > 1)
		     {
 
		     }
		     else
		     {
 
		     }
 
 
 
 
		     one o = new one(5, false);
 
		     Console.WriteLine(o.oi);
		     Console.WriteLine(o.ok);
		     Console.ReadKey();
		 }
 
		 static int Calc(int i, int k)
		 {
		     int result;
 
		     result = i + k;
		     return result;
 
		 }
 
 
		 static int Calc2(ref int i, ref int k)
		 {
		     ++i;
		     int result;
 
		     result = i + k;
		     return result;
		 }
	 }*/
	}
}