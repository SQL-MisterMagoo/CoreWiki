using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CoreWiki.Blazor.Components
{
	public class HumanizerJsInterop
	{
		public static Task ShowDuration()
		{
			// Implemented in HumanizerJsInterop.js
			return JSRuntime.Current.InvokeAsync<bool>(
					"humanizerJsInterop.showDuration", null);
		}

		public static Task ShowTimeStamps()
		{
			return JSRuntime.Current.InvokeAsync<bool>("humanizerJsInterop.showTimeStamps", null);
		}

	}
}
