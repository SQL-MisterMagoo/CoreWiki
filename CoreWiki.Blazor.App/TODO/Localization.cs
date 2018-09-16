using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.Pages
{
	public class Localizer
	{

		public virtual string this[string input] { get { return input.Replace('_',' ').ToUpper(); } }
	}
}
