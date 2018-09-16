//using Microsoft.ApplicationInsights;
using System.Collections.Generic;
using Microsoft.AspNetCore.Blazor.Services;

namespace CoreWiki.Helpers
{
	public class ArticleNotFoundResult : ViewResult
	{
		//private static TelemetryClient telemetry = new TelemetryClient();
		public ArticleNotFoundResult(string name="", IUriHelper uriHelper=null)
		{
			
			//if (!string.IsNullOrEmpty(name))		// do not track if no name was submitted
			//{
			//	var documentDictionary = new Dictionary<string, string>
			//			{
			//					{"Document", name }
			//			};

			//	telemetry.TrackEvent("Missing Document", documentDictionary);

			//}
			ViewName = "ArticleNotFound";
			StatusCode = 404;
			uriHelper.NavigateTo(ViewName);
		}
	}

}
