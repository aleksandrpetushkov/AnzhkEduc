using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbProvider
{
		public class Sverka
		{
		public int gs_key{ get; }
		public int inc{ get; }
		public int stk{ get; }
		public int lev{ get; }
		public int sver{ get; }

		public Sverka(int _gs_key, int _inc, int _stk, int _lev, int _sver)
		{
			gs_key = _gs_key;
			inc = _inc;
			stk = _stk;
			lev = _lev;
			sver = _sver;
		}

		}
}
