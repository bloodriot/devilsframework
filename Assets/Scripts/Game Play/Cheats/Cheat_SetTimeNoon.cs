// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;

namespace DI.Core.Cheat
{
	public class Cheat_SetTimeNoon : DI_Cheat, DI_CheatInterface
	{
		GameObject sun;

		public void activate()
		{
			if (sun == null) {
				sun = GameObject.Find("Directional Light");
			}

			sun.transform.rotation = Quaternion.Euler(new Vector3(DI_World.convertTimeToSunAngle(12, 0), 0f, 0f));
			DI_Debug.writeLog(DI_DebugLevel.INFO, "Enabling cheat: Cheat_SetTimeNoon");
			isCheatActive = true;
		}

		public void deactivate()
		{
			if (sun == null) {
				sun = GameObject.Find("Directional Light");
			}

			sun.transform.rotation = Quaternion.Euler(new Vector3(DI_World.convertTimeToSunAngle(6, 0), 0f, 0f));
			DI_Debug.writeLog(DI_DebugLevel.INFO, "Disabling cheat: Cheat_SetTimeNoon");
			isCheatActive = false;
		}

		public bool isActive()
		{
			return isCheatActive;
		}
	}
}