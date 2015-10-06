// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using DI.Core.Debug;

namespace DI.Core.Behaviours
{
	public interface DI_Behaviour
	{
		void log(string message);
		void log(DI_DebugLevel debugLevel, string message);
	}
}