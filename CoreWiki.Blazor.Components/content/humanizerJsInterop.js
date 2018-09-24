// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.humanizerJsInterop = {
	showDuration: function () {
		$('.duration').each(function () {
			var duration = Number($(this).attr('data-duration'));
			$(this).text(moment.duration(duration).humanize());
		});
		return true;
	}
	,
	showTimeStamps: function () {

		$(".timeStampValue").each(function () {
			var thisTimeStamp = $(this).attr('data-value');
			var date = new Date(thisTimeStamp);
			$(this).text(moment(date).format('LLL'));
		});
		return true;
	}
};
