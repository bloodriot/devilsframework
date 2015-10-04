// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;

namespace DI.Core
{
	public static class DI_Time
	{
		public static float timeMultiplier = 1f;
		public static float timeSinceLevelLoadOffset = 0f;
		public static float lastTimeSinceLevelLoad  = 0f;

		public static void pauseGame()
		{
			timeMultiplier = 0f;
			lastTimeSinceLevelLoad = Time.timeSinceLevelLoad - timeSinceLevelLoadOffset;
		}

		public static void resumeGame()
		{
			timeMultiplier = 1f;
			timeSinceLevelLoadOffset = Time.timeSinceLevelLoad - lastTimeSinceLevelLoad;
		}

		public static float getTimeDelta()
		{
			return (Time.deltaTime * timeMultiplier);
		}

		public static float getTimeSinceLevelLoad()
		{
			return (Time.timeSinceLevelLoad - timeSinceLevelLoadOffset);
		}

		public static void setTimeMultipler(float multiplier)
		{
			timeMultiplier = multiplier;
		}

		public static float getTimeMultipler()
		{
			return timeMultiplier;
		}
	}
}