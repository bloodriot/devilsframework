// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEditor;
using UnityEngine;

namespace DI.Editor
{
	public static class DI_SetupScene
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

		[MenuItem("Devil's Inc Studios/Editor/Scene/Setup Scene")]
		public static void setupScene()
		{
			createGameObject("Cameras");
			createGameObject("Dynamic Objects");
			GameObject gamePlay = createGameObject("Gameplay");
			createGameObject("Actors", gamePlay);
			createGameObject("Items", gamePlay);
			GameObject gui = createGameObject("GUI");
			createGameObject("HUD", gui);
			createGameObject("Menu", gui);
			createGameObject("Management");
			createGameObject("Lights");
			GameObject world = createGameObject("World");
			createGameObject("Ground", world);
			createGameObject("Props", world);
			createGameObject("Structure", world);
		}
	}
}