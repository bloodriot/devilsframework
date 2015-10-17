// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace DI.Core.Debug
{
	public class Editor_DebugWindow : EditorWindow
	{
		public static EditorWindow instance;
		public Vector2 debugLogScroll = new Vector2(0,0);
		public Color baseGUIColor = Color.clear;
		public int visableDetailIndex = 0;
		public List<bool> debugLevelsEnabled;
		public Vector2 detailsScroll = new Vector2(0,0);
		public Texture2D alternateBackground;
		public Texture2D mainBackground;
		public Texture2D baseBackground;

		public bool initalized = false;
		[MenuItem ("Devil's Inc Studios/Debug/Debug Console")]
		public static void showWindow()
		{
			if (instance == null) {
				instance = EditorWindow.GetWindow(typeof(Editor_DebugWindow));
			}

//			EditorWindow Editor_DebugWindow = instance;
		}

		public void init()
		{
			if (baseGUIColor == Color.clear) {
				baseGUIColor = GUI.color;
			}
			
			if (debugLevelsEnabled == null) {
				debugLevelsEnabled = new List<bool>();
				for (int debugLevel = 0; debugLevel < Enum.GetValues(typeof(DI_DebugLevel)).Length; debugLevel++) {
					debugLevelsEnabled.Add(false);
				}
			}

			if (alternateBackground == null) {
				alternateBackground = (Texture2D) Resources.Load("gui skin/grey-alt", typeof(Texture2D));
			}

			if (mainBackground == null) {
				mainBackground = (Texture2D) Resources.Load("gui skin/grey", typeof(Texture2D));
			}
			initalized  = true;
		}
		public void OnGUI()
		{
			if (!initalized) {
				init ();
			}

			// Create a list of tabs for each debug level.
			EditorGUILayout.BeginHorizontal();
			for (int debugLevel = 0; debugLevel < Enum.GetNames(typeof(DI_DebugLevel)).Length; debugLevel++) {
				DI_DebugLevel level = (DI_DebugLevel)debugLevel;
				if (debugLevelsEnabled[(int) debugLevel]) {
					GUI.color = Color.green;
				}
				else {
					GUI.color = Color.red;
				}
				if (GUILayout.Button(Enum.GetName(typeof(DI_DebugLevel), level))) {
					debugLevelsEnabled[(int) debugLevel] = !debugLevelsEnabled[(int) debugLevel];
				}
				GUI.color = baseGUIColor;
			}
			EditorGUILayout.EndHorizontal();

			debugLogScroll = EditorGUILayout.BeginScrollView(debugLogScroll);
			if (DI_Debug.debugLog != null) {
				int visableLogEntryNumber = 0;
				for (int logIndex = 0; logIndex < DI_Debug.debugLog.Count; logIndex++) {
					if (debugLevelsEnabled[(int) DI_Debug.debugLog[logIndex].logLevel]) {
						GUIStyle style = new GUIStyle("Label");
						style.normal.textColor = DI_Debug.getDebugLevelColor(DI_Debug.debugLog[logIndex].logLevel);
						if (visableLogEntryNumber % 2 == 0) {
							style.normal.background = mainBackground;
						}
						else {
							style.normal.background = alternateBackground;
						}
						if (GUILayout.Button(DI_Debug.debugLog[logIndex].message, style)) {
							visableDetailIndex = logIndex;
						}
						visableLogEntryNumber++;
					}
				}
			}
			EditorGUILayout.EndScrollView();

			GUI.backgroundColor = Color.grey;

			EditorGUILayout.BeginVertical();
			detailsScroll = EditorGUILayout.BeginScrollView(detailsScroll, GUILayout.MinHeight(100.0f));
			if (DI_Debug.debugLog != null) {
				if (DI_Debug.debugLog.Count >= visableDetailIndex) {
					GUI.enabled = false;
					EditorGUILayout.TextArea(DI_Debug.debugLog[visableDetailIndex].details.ToString(), GUILayout.MinHeight(100.0f));
					GUI.enabled = true;
				}
			}
			EditorGUILayout.EndScrollView();
			EditorGUILayout.EndVertical();
		}
	}
}