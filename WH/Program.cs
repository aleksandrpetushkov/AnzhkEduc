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
				
				WH OurWh = new WH(dal);
				int t = 0;
				while(t != 99)
				{
					Console.WriteLine(@"------------------
Выберите пункт меню:
1.Ввести поставщика;
2.Все поставщики;
3.Ввести потребителя; 
4.Все потребители; 
5.Ввести товар; 
6.Все товары; 
7.Ввести приход; 
8.Показать приход; 
9.Показать остаток;
10.Провести сверку остатков;
Или нажмите 99 для выхода:");
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
								OurWh.InsertPrvd(st);
							break;
						case 2:
							Console.WriteLine("Все поставщики:\n");
							foreach(KeyValuePair<int, Provider> provider in OurWh.prvds)
								Console.WriteLine($"Номер: {provider.Key} Название: {provider.Value.nm}");
							///wh.prvds
							break;
						case 3:
							Console.WriteLine("Ввести потребителя:");
							st = Console.ReadLine();
							string check2 = st.Replace(";", "").Replace(":", "");
							if(st.Length != check2.Length)
								Console.WriteLine("Не корректный ввод, повтрите");
							else
								OurWh.InsertCs(st);
							break;
						case 4:
							Console.WriteLine("Все потребители:\n");
							foreach(KeyValuePair<int, Consumer> consumer in OurWh.cs) 
								Console.WriteLine($"Номер: {consumer.Key} Название: {consumer.Value.nm}");
							break;
						
						case 5:
							Console.WriteLine("Ввести товар:");
							st = Console.ReadLine();
							string check3 = st.Replace(";", "").Replace(":", "");
							if(st.Length != check3.Length)
								Console.WriteLine("Не корректный ввод, повторите");
							else
								OurWh.InsertGoods(st);
							break;
						case 6:
							Console.WriteLine("Все товары:\n");
							foreach(KeyValuePair<int, Goods> goods in OurWh.gs) Console.WriteLine($"Номер: {goods.Key} Название: {goods.Value.nm}");
							break;
						case 7:
							Console.WriteLine("-----------------------\nВсе товары:\n");
							foreach(KeyValuePair<int, Goods> goods in OurWh.gs) Console.WriteLine($"Номер: {goods.Key} Название: {goods.Value.nm}");
							Console.WriteLine("Все поставщики:\n");
							foreach(KeyValuePair<int, Provider> provider in OurWh.prvds)
								Console.WriteLine($"Номер: {provider.Key} Название: {provider.Value.nm}");
							
							Console.WriteLine(
								"----------------\nВвести приход: введите через запятую пк товара, пк поставщика, цену товара и количество товара (в кг)");
							st = Console.ReadLine();
							//расписать действие в 3 итерации
							string[] mas = st.Split(',', ' ', ';');
							
							if(mas.Length != 4)
							{
								Console.WriteLine("Не корректный ввод, повторите");
								continue;
							}
							// int[] mas_int - объявление и инициальзация
							int[] mas_int = new int[4];
							
							bool chek = false;
							for(int i = 0; i < mas.Length; i++)
							{
								//обращение к какой-либо перменной или методу - это НАПИСАТЬ НАЗВАНИЕ ЭТОГО(написать название метода или переменной)
								Console.WriteLine($"Вы ввели: {mas[i]}");
								if(!int.TryParse(mas[i], out mas_int[i]))
								{
									Console.WriteLine("Не корректный ввод, повторите");
									chek = false;
									break;
								}
								else
								{
									chek = true;
								}
							}
							
							if(chek)
							{
								if(OurWh.gs.TryGetValue(mas_int[0], out Goods g) && OurWh.prvds.TryGetValue(mas_int[1], out Provider prov))
								{
									Console.WriteLine($"Вы ввели: Название товара: {OurWh.gs[mas_int[0]].nm} Поставщик: {OurWh.prvds[mas_int[1]].nm} " +
									                  $"Цена: {mas_int[2]} Количество: {mas_int[3]} \nПодтвердить ввод: 1-да, !1-нет");
								}
								else
								{
									Console.WriteLine("Вы пытались обратиться к несуществующему объекту");
									break;
								}
								

								if(int.TryParse(Console.ReadLine(), out int z) && z == 1)
								{
									
									OurWh.AddIncom(mas_int[0], mas_int[1], mas_int[2], mas_int[3]);
								}
								else
								{
									Console.WriteLine("Вы отказались от ввода");
								}
								
							}
							break;
						case 8:
							Console.WriteLine("Показать приход:\n");
							foreach(KeyValuePair<int, Incoming> inc in OurWh.incom)
							{
								Console.WriteLine($"Номер: {inc.Key} Товар: {OurWh.gs[inc.Value.goods_pk].nm} Поставщик: {OurWh.prvds[inc.Value.provider_pk].nm} Цена: {inc.Value.price} Количество: {inc.Value.count}");
							}
							break;
						case 9:
							Console.WriteLine("Показать остаток:\n");
							foreach(KeyValuePair<int, Stocks> stk in OurWh.stock)
							{
								Console.WriteLine($"Товар: {OurWh.gs[stk.Value.pk_gs].nm} Количество {stk.Value.count}");
							}
							break;
						case 10:
							Console.WriteLine("Провести сверку остатков:\n");
							foreach(KeyValuePair<int, Goods> gds in OurWh.gs)
							{
								if(OurWh.KH(gds.Key, out int inc, out int stk, out int lev, out int sver))
								{
									Console.WriteLine($"Было движение по {gds.Value} Приход: {inc} Остаток: {stk} Расход: {lev} Сверка:{sver}");
									
								}
								else
								{
									Console.WriteLine($"Не было движения по {gds.Value}");
								}
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