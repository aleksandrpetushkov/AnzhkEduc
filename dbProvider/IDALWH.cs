using System.Collections.Generic;

namespace dbProvider
{
	public interface IDALWH
	{
		Dictionary<int, Provider> GetPrvds();
		Dictionary<int, Consumer> GetConsumers();
		void InsertPrvd(string st);
		void InsertCs(string st);
		void InsertGoods(string st);
		Dictionary<int, Goods> GetGoods();
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="goods_pk">pk godds</param>
		/// <param name="provider_pk">pk prowide</param>
		/// <param name="price">price</param>
		/// <param name="count"></param>
		void InsertIncom(int goodsPk, int providerPk, int price, int count);

		Dictionary<int, Incoming> GetIncom();
	}
}