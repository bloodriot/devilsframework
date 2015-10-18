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
	[AddComponentMenu("Devil's Inc Studios/Managers/Input")]
	public class InputManager : DI_MonoBehaviourSingleton<InputManager>
	{
		[Header("Debug bindings.")]
		public List<DI_KeyBind> bindings;

		[Header("Input Processing")]
		[Tooltip("Should we be processing input updates?")]
		public bool updatingInput = true;

		public void Awake()
		{
			if (!makeSingleton(this)) {
				Destroy(this);
			}
		}

		public void OnEnable()
		{
			DI_BindManager.loadBoundKeys();
		}

		public void Update()
		{
			if (updatingInput) {
				bindings = DI_BindManager.bindings.boundKeys[0];

				// TODO check what players are actually playing and ignore events from players not in the game.
				for (int playerIndex = 0; playerIndex < DI_BindManager.bindings.boundKeys.Count; playerIndex++) {
					for (int bindIndex = 0; bindIndex < DI_BindManager.bindings.boundKeys[playerIndex].Count; bindIndex++) {
						switch (DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindType) {
						case DI_KeyBindType.BIND_AXIS:
							float axisTilt = UnityEngine.Input.GetAxis(DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindKey);
							if (axisTilt > 0.0f) {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.AXIS_POSITIVE;
							}
							else if (axisTilt < 0.0f) {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.AXIS_NEGATIVE;
							}
							else {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.AXIS_NOT_PRESSED;
							}
							break;
						case DI_KeyBindType.BIND_BUTTON:
							bool buttonDown = UnityEngine.Input.GetButtonDown(DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindKey);
							if (buttonDown && DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState == DI_KeyState.KEY_NOT_PRESSED) {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.KEY_PRESSED;
							}
							else if (buttonDown && DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState == DI_KeyState.KEY_PRESSED) {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.KEY_HELD;
							}
							else {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.KEY_NOT_PRESSED;
							}
							break;
						case DI_KeyBindType.BIND_KEY:
							bool keyDown = UnityEngine.Input.GetKeyDown(DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindKey);
							if (keyDown && DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState == DI_KeyState.KEY_NOT_PRESSED) {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.KEY_PRESSED;
							}
							else if (keyDown && DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState == DI_KeyState.KEY_PRESSED) {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.KEY_HELD;
							}
							else {
								DI_BindManager.bindings.boundKeys[playerIndex][bindIndex].bindState = DI_KeyState.KEY_NOT_PRESSED;
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
}