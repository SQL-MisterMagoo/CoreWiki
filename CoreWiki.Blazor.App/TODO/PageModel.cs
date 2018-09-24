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
		public Data.EntityFramework.Security.CoreWikiUser User;
		public RedirectResult Redirect(string target) { return new RedirectResult(target); }
		public Response Response;
		public Request Request;
		public PageModel()
		{
			ModelState = new ModelState() { IsValid = true };
			User = new Data.EntityFramework.Security.CoreWikiUser()
			{
				Id = "Fake User",
				Email = "fakeuser@mail.com",
				EmailConfirmed = true,
				NormalizedUserName = "Fake User",
				UserName = "Fake User"
			};			
		}
	}
	public class ModelState
	{
		public bool IsValid;
		private Dictionary<string, List<string>> _modelErrors  = new Dictionary<string, List<string>>();

		public void AddModelError(string fieldName, string message)
		{
			var errors = _modelErrors[fieldName];
			if (errors == null)
			{
				errors = new List<string>();
			}
			errors.Add(message);
			_modelErrors[fieldName] = errors;
		}
	}
}
