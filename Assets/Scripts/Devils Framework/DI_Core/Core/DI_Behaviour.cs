// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using UnityEngine;

namespace DI.Core
{
	public interface DI_Behaviour
	{
		void log(string message);
		void log(DI_DebugLevel debugLevel, string message);
	}
}