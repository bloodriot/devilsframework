// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using UnityEngine;
using DI.Core.Debug;

namespace DI.Core.Behaviours
{
	public class DI_MonoBehaviour : MonoBehaviour, DI_Behaviour
	{
		public void log(string message) {
			DI_Debug.writeLog(DI_DebugLevel.INFO, message);
		}
		
		public void log(DI_DebugLevel debugLevel, string message) {
			DI_Debug.writeLog(debugLevel, message);
		}
	}
}