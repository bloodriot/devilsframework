// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEditor;

namespace DI.Core.Cheat
{
	public static class Cheat_SetTimeNoonEnable
	{
		private static DI_CheatInterface cheat;

		[MenuItem("Devil's Inc Studios/Cheats/Set Time Noon/Enable")]
		public static void enable()
		{
			if (cheat == null) {
				cheat = (DI_CheatInterface) new Cheat_SetTimeNoon();
			}
			cheat.activate();
		}

		[MenuItem("Devil's Inc Studios/Cheats/Set Time Noon/Disable")]
		public static void disable()
		{
			if (cheat == null) {
				cheat = (DI_CheatInterface) new Cheat_SetTimeNoon();
			}
			cheat.deactivate();
		}
	}
}