using Microsoft.AspNetCore.Blazor.Services;

namespace CoreWiki.Helpers
{
	public class RedirectResult : ViewResult
	{
		public RedirectResult(string redirectTo, IUriHelper uriHelper)
		{
			ViewName = redirectTo;
			StatusCode = 201;
			uriHelper.NavigateTo(redirectTo);
		}
	}
}
