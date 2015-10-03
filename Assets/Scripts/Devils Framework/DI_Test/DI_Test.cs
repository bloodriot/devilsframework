// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Core;

namespace DI.Test
{
	public class DI_Test
	{
		public bool isEqual<T>(T objectOne, T objectTwo, string description)
		{
			if (objectOne.Equals(objectTwo)) {
				DI_Debug.writeLog(DI_DebugLevel.INFO, "isEqual: " + objectOne.GetType().ToString() + " vs: " + objectTwo.GetType().ToString() + " returned: true");
				return true;
			}
			else {
				DI_Debug.writeLog(DI_DebugLevel.INFO, "isEqual: " + objectOne.GetType().ToString() + " vs: " + objectTwo.GetType().ToString() + " returned: false");
				return false;
			}
		}
		public bool isNotEqual<T>(T objectOne, T objectTwo, string description)
		{
			if (!objectOne.Equals(objectTwo)) {
				DI_Debug.writeLog(DI_DebugLevel.INFO, "isNotEqual: " + objectOne.GetType().ToString() + " vs: " + objectTwo.GetType().ToString() + " returned: true");
				return true;
			}
			else {
				DI_Debug.writeLog(DI_DebugLevel.INFO, "isNotEqual: " + objectOne.GetType().ToString() + " vs: " + objectTwo.GetType().ToString() + " returned: false");
				return false;
			}
		}
	}
}