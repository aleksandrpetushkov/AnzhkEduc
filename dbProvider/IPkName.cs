using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbProvider
{
	internal interface IPkName
	{
		int Pk{ get; }
		string Name{ get; }
	}
}