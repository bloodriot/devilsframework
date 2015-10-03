// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using UnityEngine;

namespace DI.Core
{
	public class DI_MonoBehaviour : MonoBehaviour, DI_Behaviour
	{
		void DI_Behaviour.log(string message) {
			DI_Debug.writeLog(DI_DebugLevel.INFO, message);
		}
		
		void DI_Behaviour.log(DI_DebugLevel debugLevel, string message) {
			DI_Debug.writeLog(debugLevel, message);
		}
	}
}