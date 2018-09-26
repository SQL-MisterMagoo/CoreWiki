using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System;

namespace CoreWiki.Helpers
{
	public class RedirectResult : ViewResult, IDisposable
	{
		[Inject] public IUriHelper _uriHelper { get; set; }
		public string RedirectTo { get; }

		public RedirectResult(string redirectTo)
		{
			ViewName = redirectTo;
			StatusCode = 201;
			RedirectTo = redirectTo;
		}

		public void Dispose()
		{
			_uriHelper?.NavigateTo(RedirectTo);
		}
	}
}
