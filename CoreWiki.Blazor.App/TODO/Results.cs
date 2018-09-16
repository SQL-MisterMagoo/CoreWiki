using Microsoft.AspNetCore.Blazor.Services;

namespace CoreWiki.Helpers
{
	public interface IViewResult
	{

	}

	public class ViewResult : IViewResult, IActionResult
	{
		public string ViewName;
		public int StatusCode;

	}

	public interface IActionResult { }
}
