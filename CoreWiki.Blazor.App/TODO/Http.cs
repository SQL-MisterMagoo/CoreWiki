using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Storage;

namespace CoreWiki.ViewModels
{
	public class Request
	{
		private static ILocalStorage _storage;

		public Request(ILocalStorage localStorage)
		{
			_storage = localStorage;
			Cookies = new Cookies(_storage);
		}

		public static Cookies Cookies;
	}

	public class Response
	{
		private static ILocalStorage _storage;

		public Response(ILocalStorage localStorage)
		{
			_storage = localStorage;
			Cookies = new Cookies(_storage);
		}

		public static Cookies Cookies;
	}

	public class Cookies
	{
		private readonly ILocalStorage _storage;

		public Cookies(ILocalStorage localStorage)
		{
			_storage = localStorage;
		}

		public virtual string this[string input]
		{
			get
			{
				return _storage.GetItem<string>(input).Result;
			}
		}

		public virtual void Append(string name, string value, object options)
		{
			_storage.SetItem(name, value);
		}
	}
}

namespace Microsoft.AspNetCore.Http
{
	public class CookieOptions
	{
		public DateTime Expires;
	}
}

namespace Microsoft.AspNetCore.Mvc { }
namespace Microsoft.AspNetCore.Mvc.RazorPages { }
