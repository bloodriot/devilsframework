// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;
using System.Collections.Generic;
using System;

using DI.Core.Behaviours;
using DI.Core.Events;
using DI.Core.Debug;

namespace DI.Core.Input
{
	public class InputManager : DI_MonoBehaviour
	{
		[HideInInspector]
		public static InputManager instance;

		[Header("Debug values: DO NOT EDIT MANUALLY!")]
		public List<DI_KeyBind> binds;
		public List<int> bindIndex;
		public List<DI_KeyState> bindState;

		[Header("Input Processing")]
		[Tooltip("Should we be processing input updates?")]
		public bool updatingInput = true;

		public void updateBindingCache()
		{
			binds = new List<DI_KeyBind>();
			bindIndex = new List<int>();
			bindState = new List<DI_KeyState>();

			for (int player = 0; player < DI_BindManager.bindings.boundKeys.Count; player++) {
				for (int keyIndex = 0; keyIndex < DI_BindManager.bindings.boundKeys[player].Count; keyIndex++) {
					binds.Add(DI_BindManager.bindings.boundKeys[player][keyIndex]);
					bindIndex.Add(keyIndex);
					bindState.Add(DI_KeyState.KEY_NOT_PRESSED);
				}
			}
		}

		public void Awake()
		{
			if (instance == null) {
				instance = this;
			}
			else {
				log(DI_DebugLevel.INFO, "Attempted to create a new instance of a singleton class, cleaning up the duplicate.");
				Destroy(this);
			}
		}

		public void OnEnable()
		{
			DI_BindManager.loadBoundKeys();
			updateBindingCache();
		}

		public void Update()
		{
			if (updatingInput) {
				// TODO check what players are actually playing and ignore events from players not in the game.
				for (int index = 0; index < binds.Count; index++) {
					switch (binds[index].bindType) {
						case DI_KeyBindType.BIND_AXIS:
							if (UnityEngine.Input.GetAxis(binds[index].bindKey) > binds[index].deadZone) {
								if (bindState[index] != DI_KeyState.AXIS_POSITIVE) {
									DI_EventCenter<int, DI_KeyState>.invoke("OnInputEvent-" + binds[index].bindName, binds[index].playerId, DI_KeyState.AXIS_POSITIVE);
									bindState[index] = DI_KeyState.AXIS_POSITIVE;
									log(DI_DebugLevel.LOW, "InputManager: Changing state to AXIS_POSITVE for bind: " + binds[index].bindName + " on player: " + binds[index].playerId);
								}
							}
							else if (UnityEngine.Input.GetAxis(binds[index].bindKey) < binds[index].deadZone * -1) {
								if (bindState[index] != DI_KeyState.AXIS_NEGATIVE) {
									DI_EventCenter<int, DI_KeyState>.invoke("OnInputEvent-" + binds[index].bindName, binds[index].playerId, DI_KeyState.AXIS_NEGATIVE);
									bindState[index] = DI_KeyState.AXIS_NEGATIVE;
									log(DI_DebugLevel.LOW, "InputManager: Changing state to AXIS_NEGATIVE for bind: " + binds[index].bindName + " on player: " + binds[index].playerId);
								}
							}
							else {
								if (bindState[index] != DI_KeyState.AXIS_NOT_PRESSED) {
									DI_EventCenter<int, DI_KeyState>.invoke("OnInputEvent-" + binds[index].bindName, binds[index].playerId, DI_KeyState.AXIS_NOT_PRESSED);
									bindState[index] = DI_KeyState.AXIS_NOT_PRESSED;
									log(DI_DebugLevel.LOW, "InputManager: Changing state to AXIS_NOT_PRESSED for bind: " + binds[index].bindName + " on player: " + binds[index].playerId);
								}
							}
						break;

						case DI_KeyBindType.BIND_KEY:
							if (UnityEngine.Input.GetKeyDown(binds[index].bindKey)) {
								// If the key is just now being pressed, move it to a pressed state.
								if (bindState[index] != DI_KeyState.KEY_PRESSED) {
									DI_EventCenter<int, DI_KeyState>.invoke("OnInputEvent-" + binds[index].bindName, binds[index].playerId, DI_KeyState.KEY_PRESSED);
									bindState[index] = DI_KeyState.KEY_PRESSED;
									log(DI_DebugLevel.LOW, "InputManager: Changing state to KEY_PRESSED for bind: " + binds[index].bindName + " on player: " + binds[index].playerId);
								}
							}
							else if (UnityEngine.Input.GetKey(binds[index].bindKey)) {
								// If the key is being held down, move it to a held state.
								if (bindState[index] != DI_KeyState.KEY_HELD) {
									DI_EventCenter<int, DI_KeyState>.invoke("OnInputEvent-" + binds[index].bindName, binds[index].playerId, DI_KeyState.KEY_HELD);
									bindState[index] = DI_KeyState.KEY_HELD;
									log(DI_DebugLevel.LOW, "InputManager: Changing state to KEY_HELD for bind: " + binds[index].bindName + " on player: " + binds[index].playerId);
								}
							}
							// If the key is not pressed, move it to a pressed state.
							else {
								if (bindState[index] != DI_KeyState.KEY_NOT_PRESSED) {
									DI_EventCenter<int, DI_KeyState>.invoke("OnInputEvent-" + binds[index].bindName, binds[index].playerId, DI_KeyState.KEY_NOT_PRESSED);
									bindState[index] = DI_KeyState.KEY_NOT_PRESSED;
									log(DI_DebugLevel.LOW, "InputManager: Changing state to KEY_NOT_PRESSED for bind: " + binds[index].bindName + " on player: " + binds[index].playerId);
								}
							}
						break;

						default:
							log(DI_DebugLevel.CRITICAL, "Hit unexpected bind type when updating input.");
						break;
					}
				}
			}
		}
	}
}