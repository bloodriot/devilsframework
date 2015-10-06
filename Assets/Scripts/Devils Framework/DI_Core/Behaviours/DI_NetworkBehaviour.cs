// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using UnityEngine.Networking;
using DI.Core.Debug;

namespace DI.Core.Behaviours
{
	public class DI_NetworkBehaviour : NetworkBehaviour, DI_Behaviour
	{
		void DI_Behaviour.log(string message) {
			DI_Debug.writeLog(DI_DebugLevel.INFO, message);
		}
		
		void DI_Behaviour.log(DI_DebugLevel debugLevel, string message) {
			DI_Debug.writeLog(debugLevel, message);
		}
	}
}