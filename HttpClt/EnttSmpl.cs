using System;
using Newtonsoft.Json;

namespace HttpClt
{
	[Serializable]
	public class EnttSmpl
	{
		[JsonConstructor]
		public EnttSmpl(ushort i, string one, string two)
		{
			oneProp = one;
			twoProp = two;
			I = i;
		}

		public string oneProp;
		public string twoProp;
		public ushort I;
	}
}