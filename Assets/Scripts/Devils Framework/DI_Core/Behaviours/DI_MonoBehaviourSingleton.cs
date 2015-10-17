// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Core.Debug;

namespace DI.Core.Behaviours
{
	public class DI_MonoBehaviourSingleton<T> : DI_MonoBehaviour
	{
		public static T instance;

		public bool makeSingleton(T child)
		{
			if (instance == null) {
				instance = (T)child;
				return true;
			}
			else {
				log(DI_DebugLevel.INFO, "Attempted to create a new instance of a singleton class, cleaning up the duplicate.");
				return false;
			}
		}
	}
}