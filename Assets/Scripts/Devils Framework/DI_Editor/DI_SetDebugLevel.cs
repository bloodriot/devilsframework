// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEditor;

using DI.Core.Debug;

namespace DI.Editor
{
	public static class DI_SetDebugLevel
	{
		[MenuItem("Devil's Inc Studios/Debug/Set Debug Level/All")]
		public static void setDebugLevelAll()
		{
			DI_Debug.setGobalDebugLevel(DI_DebugLevel.ALL);
		}

		[MenuItem("Devil's Inc Studios/Debug/Set Debug Level/Info")]
		public static void setDebugLevelInfo()
		{
			DI_Debug.setGobalDebugLevel(DI_DebugLevel.INFO);
		}

		[MenuItem("Devil's Inc Studios/Debug/Set Debug Level/Low")]
		public static void setDebugLevelLow()
		{
			DI_Debug.setGobalDebugLevel(DI_DebugLevel.LOW);
		}

		[MenuItem("Devil's Inc Studios/Debug/Set Debug Level/Medium")]
		public static void setDebugLevelMedium()
		{
			DI_Debug.setGobalDebugLevel(DI_DebugLevel.MEDIUM);
		}

		[MenuItem("Devil's Inc Studios/Debug/Set Debug Level/High")]
		public static void setDebugLevelHigh()
		{
			DI_Debug.setGobalDebugLevel(DI_DebugLevel.HIGH);
		}

		[MenuItem("Devil's Inc Studios/Debug/Set Debug Level/Critical")]
		public static void setDebugLevelCritical()
		{
			DI_Debug.setGobalDebugLevel(DI_DebugLevel.CRITICAL);
		}

		[MenuItem("Devil's Inc Studios/Debug/Set Debug Level/None")]
		public static void setDebugLevelNone()
		{
			DI_Debug.setGobalDebugLevel(DI_DebugLevel.NONE);
		}
	}
}