// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;

namespace DI.Core
{
	public static class DI_World
	{
		public static float convertTimeToSunAngle(int hours, int minutes)
		{
			float minuteAngle = 0.25f;
			float start = 270.0f;

			float totalMinutes = hours * 60 + minutes;

			float angle = start + (totalMinutes * minuteAngle);

			if (angle > 360) {
				angle -= 360;
			}

			return angle;
		}
	}
}