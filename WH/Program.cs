using System;
using System.Collections.Generic;
using dbProvider;

namespace WH
{
	/// <summary>
	///     Level Interface - create the main menu
	/// </summary>
	internal class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Добро пожаловать в программу склад");
			try //блок трай
			{
				IDALWH dal = new PgProvider("h.petushkov.com", "ang", "ang", "warehouse", "tst_wh");
				;
				WH wh = new WH(dal);
				int t = 0;
				while(t != 99)
				{
					Console.WriteLine($"------------------Выберите пункт меню: \n1" + $".Ввести поставщика; \n2.Ввести потребителя; \n" +
					                  $"3.Все потребители; \n4.Все поставщики; \n" + $"5.Ввести товар: \n6.Все товары; \n" + $"7.Ввести приход; \n" +
					                  $"8.Показать приход; \n" + $"Или нажмите 99 для выхода:");
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
							string check = st.Replace(";", "").Replace(":", "");
							if(st.Length != check.Length)
							{
								Console.WriteLine("Не корректный ввод, повторите");
							}
							else
								wh.InsertPrvd(st);
							break;
						case 2:
							Console.WriteLine("Ввести потребителя:");
							st = Console.ReadLine();
							string check2 = st.Replace(";", "").Replace(":", "");
							if(st.Length != check2.Length)
								Console.WriteLine("Не корректный ввод, повтрите");
							else
								wh.InsertCs(st);
							break;
						case 3:
							Console.WriteLine("Все потребители:\n");
							foreach(KeyValuePair<int, Consumer> consumer in wh.cs)
							{
								Console.WriteLine($"Номер: {consumer.Key} Название: {consumer.Value.nm}");
							}
							break;
						case 4:
							Console.WriteLine("Все поставщики:\n");
							foreach(KeyValuePair<int, Provider> provider in wh.prvds)
								Console.WriteLine($"Номер: {provider.Key} Название: {provider.Value.nm}");
							///wh.prvds
							break;
						case 5:
							Console.WriteLine("Ввести товар:");
							st = Console.ReadLine();
							string check3 = st.Replace(";", "").Replace(":", "");
							if(st.Length != check3.Length)
								Console.WriteLine("Не корректный ввод, повторите");
							else
								wh.InsertGoods(st);
							break;
						case 6:
							Console.WriteLine("Все товары:\n");
							foreach(KeyValuePair<int, Goods> goods in wh.gs) Console.WriteLine($"Номер: {goods.Key} Название: {goods.Value.nm}");
							break;
						case 7:
							Console.WriteLine("Все поставщики:\n");
							foreach(KeyValuePair<int, Provider> provider in wh.prvds)
								Console.WriteLine($"Номер: {provider.Key} Название: {provider.Value.nm}");
							Console.WriteLine("-----------------------\nВсе товары:\n");
							foreach(KeyValuePair<int, Goods> goods in wh.gs) Console.WriteLine($"Номер: {goods.Key} Название: {goods.Value.nm}");
							Console.WriteLine(
								"----------------\nВвести приход: введите через запятую пк товара, пк поставщика, цену товара и количество товара (в кг)\n");
							st = Console.ReadLine();
							string[] mas = st.Split(",");
							int[] mass = new int[4];
							for(int i = 0; i < mas.Length; i++)
							{
								Console.WriteLine($"Вы ввели: {mas[i]}");
								int.TryParse(mas[i], out mass[i]);
							}
							wh.AddIncom(mass[0], mass[1], mass[2], mass[3]);
							break;
						case 8:
							Console.WriteLine("Показать приход:\n");
							foreach(KeyValuePair<int, Incoming> inc in wh.incom)
							{
								Console.WriteLine(
									$"Номер: {inc.Key} Товар: {wh.gs[inc.Value.goods_pk].nm} Поставщик: {wh.prvds[inc.Value.provider_pk].nm} Цена: {inc.Value.price} Количество: {inc.Value.count}");
							}
							break;
						case 99:
							Console.WriteLine("Хочу выйти из ПО.");
							break;
					}
					Console.WriteLine("Нажмите кноку, чтобы продолжить");
					Console.ReadKey();
				}
			}
			catch(Exception e)
			{
				Console.WriteLine($"Что-то пошло не так:\n{e.Message}");
			}
		}
	}
}