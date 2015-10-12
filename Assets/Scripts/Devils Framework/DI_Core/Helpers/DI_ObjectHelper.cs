// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.

using UnityEngine;

namespace DI.Core.Helpers
{
	public static class DI_ObjectHelper
	{
		public static GameObject createGameObject(string name)
		{
			GameObject go = new GameObject(name);
			return go;
		}
		
		public static GameObject createGameObject(string name, GameObject parent)
		{
			GameObject go = createGameObject(name);
			go.transform.parent = parent.transform;
			return go;
		}
	}
}

