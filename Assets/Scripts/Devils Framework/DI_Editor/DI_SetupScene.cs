// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEditor;
using UnityEngine;

using DI.Core.Helpers;

namespace DI.Editor
{
	public static class DI_SetupScene
	{
		[MenuItem("Devil's Inc Studios/Editor/Scene/Setup Scene")]
		public static void setupScene()
		{
			DI_ObjectHelper.createGameObject("Cameras");
			DI_ObjectHelper.createGameObject("Dynamic Objects");
			GameObject gamePlay = DI_ObjectHelper.createGameObject("Gameplay");
			DI_ObjectHelper.createGameObject("Actors", gamePlay);
			DI_ObjectHelper.createGameObject("Items", gamePlay);
			GameObject gui = DI_ObjectHelper.createGameObject("GUI");
			DI_ObjectHelper.createGameObject("HUD", gui);
			DI_ObjectHelper.createGameObject("Menu", gui);
			DI_ObjectHelper.createGameObject("Management");
			DI_ObjectHelper.createGameObject("Lights");
			DI_ObjectHelper.createGameObject("Audio");
			GameObject world = DI_ObjectHelper.createGameObject("World");
			DI_ObjectHelper.createGameObject("Ground", world);
			DI_ObjectHelper.createGameObject("Props", world);
			DI_ObjectHelper.createGameObject("Structure", world);
		}
	}
}