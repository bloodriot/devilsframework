// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;

namespace DI.Core.Helpers
{
	public static class DI_DateTime
	{
		public static TimeSpan diffTime(DateTime start, DateTime end)
		{
			return end.Subtract(start);
		}

		static public string convertToReadableTime(float timeInSeconds)
		{
			float hours = 0;
			float minutes = 0;
			float seconds = 0;
			
			while (timeInSeconds > 3600) {
				timeInSeconds -= 3600;
				hours++;
			}
			while (timeInSeconds > 60) {
				timeInSeconds -= 60;
				minutes++;
			}
			seconds = timeInSeconds;
			if (hours > 0) {
				return (hours + ":" + minutes + ":" + seconds);
			}
			else if (minutes > 0) {
				return (minutes + ":" + seconds);
			}
			else {
				return seconds + "";
			}
		}
	}
}