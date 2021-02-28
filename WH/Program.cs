using System;
using dbProvider;

namespace WH
{
	/// <summary>
	///     Level Interface - create the main menu
	/// </summary>
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Добро пожаловать в программу склад");
			try
			{
				IDALWH dal = new PgProvider("h.petushkov.com", "ang", "ang", "warehouse", "tst_wh");
				var wh = new WH(dal);
				var t = 0;
				while(t != 99)
				{
					Console.WriteLine(
						"------------------\nВыберите пункт меню: \n1.Ввести поставщика; \n2.Ввести потребителя; \n3.Все потребители; \n4.Все поставщики; \n5.Ввести товар: \n6.Все товары; \n7.Ввести приход; \n8.Показать приход; \nИли нажмите 99 для выхода:");
					if(!int.TryParse(Console.ReadLine(), out t))
					{
						Console.WriteLine("Не корректный ввод");
						continue;
					}
					string st;
					switch(t)
					{
						case 1:
							Console.WriteLine("Ввести поставщика:");
							st = Console.ReadLine();
							var check = st.Replace(";", "").Replace(":", "");
							if(st.Length != check.Length)
								Console.WriteLine("Не корректный ввод, повторите");
							else
								wh.InsertPrvd(st);
							break;
						case 2:
							Console.WriteLine("Ввести потребителя:");
							st = Console.ReadLine();
							var check2 = st.Replace(";", "").Replace(":", "");
							if(st.Length != check2.Length)
								Console.WriteLine("Не корректный ввод, повтрите");
							else
								wh.InsertCs(st);
							break;
						case 3:
							Console.WriteLine("Все потребители:\n");
							foreach(var consumer in wh.cs) Console.WriteLine($"Номер: {consumer.Key} Название: {consumer.Value.nm}");
							break;
						case 4:
							Console.WriteLine("Все поставщики:\n");
							foreach(var provider in wh.prvds) Console.WriteLine($"Номер: {provider.Key} Название: {provider.Value.nm}");
							///wh.prvds
							break;
						case 5:
							Console.WriteLine("Ввести товар:");
							st = Console.ReadLine();
							var check3 = st.Replace(";", "").Replace(":", "");
							if(st.Length != check3.Length)
								Console.WriteLine("Не корректный ввод, повторите");
							else
								wh.InsertGoods(st);
							break;
						case 6:
							Console.WriteLine("Все товары:\n");
							foreach(var goods in wh.gs) Console.WriteLine($"Номер: {goods.Key} Название: {goods.Value.nm}");
							break;
						case 7:
							Console.WriteLine("Все поставщики:\n");
							foreach(var consumer in wh.cs) Console.WriteLine($"Номер: {consumer.Key} Название: {consumer.Value.nm}");
							Console.WriteLine("-----------------------\nВсе товары:\n");
							foreach(var goods in wh.gs) Console.WriteLine($"Номер: {goods.Key} Название: {goods.Value.nm}");
							Console.WriteLine(
								"----------------\nВвести приход: введите через запятую пк товара, пк поставщика, цену товара и количество товара (в кг)\n");
							st = Console.ReadLine();
							var mas = st.Split(",");
							var mass = new int[4];
							for(var i = 0; i < mas.Length; i++)
							{
								Console.WriteLine($"Вы ввели: {mas[i]}");
								int.TryParse(mas[i], out mass[i]);
							}
							wh.AddIncom(mass[0], mass[1], mass[2], mass[3]);
							break;
						case 8:
							Console.WriteLine("Показать приход:\n");
							foreach(var incoming in wh.incom) Console.WriteLine($"Номер: {incoming.Key} Поставщик: {incoming.Value.p_nm} Товар: {incoming.Value.g_nm} Цена: {incoming.Value.price} Количество: {incoming.Value.count}");
							break;
						case 99:
							Console.WriteLine("Хочу выйти из ПО.");
							break;
					}
				}
			}
			catch(Exception e)
			{
				Console.WriteLine($"Что-то пошло не так:\n{e.Message}");
			}
		}
	}
}