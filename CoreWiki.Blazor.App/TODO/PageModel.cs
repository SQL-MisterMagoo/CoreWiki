using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWiki.Helpers;

namespace CoreWiki.ViewModels
{
	public class PageModel
	{
		public void TryValidateModel(object model) { }
		public ModelState ModelState;
		public ViewResult Page() { return null; }
		public FakeUser User;
		public RedirectResult Redirect(string target) { return new RedirectResult(target); }
		public Response Response;
		public Request Request;
	}
	public class ModelState
	{
		public bool IsValid;
	}
}
