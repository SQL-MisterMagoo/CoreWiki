using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreWiki.Data.EntityFramework.Security;
using CoreWiki.Helpers;
using Microsoft.AspNetCore.Blazor.Services;

namespace CoreWiki.ViewModels
{
	public class PageModel
	{
		public void TryValidateModel(object model) { }
		public ModelState ModelState;
		public ViewResult Page() { return null; }
		public ClaimsPrincipal User;
		public RedirectResult Redirect(string target,IUriHelper uriHelper) { return new RedirectResult(target,uriHelper); }
		public Response Response;
		public Request Request;
		public PageModel()
		{
			ModelState = new ModelState() { IsValid = true };
			var _user = new CoreWikiUser()
			{
				Id = Guid.NewGuid().ToString(),
				Email = "fakeuser@mail.com",
				EmailConfirmed = true,
				NormalizedUserName = "Fake User",
				UserName = "Fake User"
			};
			var ci = new ClaimsIdentity(new List<Claim>() { new Claim(ClaimTypes.Name,_user.UserName)});
			User = new ClaimsPrincipal(ci);			
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
