// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using UnityEditor;

namespace DI.Core.Debug
{
	public static class DI_DebugSetLogger
	{
		[MenuItem("Devil's Inc Studios/Debug/Logger/Both")]
		public static void selectBothLoggers()
		{
			DI_Debug.setUnityLogging(true);
			DI_Debug.setCustomLogging(true);
		}

		[MenuItem("Devil's Inc Studios/Debug/Logger/Custom")]
		public static void selectCustomLogger()
		{
			DI_Debug.setUnityLogging(false);
			DI_Debug.setCustomLogging(true);
		}

		[MenuItem("Devil's Inc Studios/Debug/Logger/Unity")]
		public static void selectUnityLogger()
		{
			DI_Debug.setUnityLogging(true);
			DI_Debug.setCustomLogging(false);
		}
	}
}