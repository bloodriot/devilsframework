// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

using DI.Core.Behaviours;
using DI.Core.Debug;
using DI.Core.Events;

namespace DI.Core.GameState
{
	public class GameStateManager : DI_MonoBehaviourSingleton<GameStateManager>
	{
		[Header("Debug view of players one and twos game states.")]
		[SerializeField]
		protected DI_GameStates playerOneGameState;
		[SerializeField]
		protected DI_GameStates playerTwoGameState;
		[Header("Game State Transition Settings.")]
		[SerializeField]
		protected List<DI_StateTransition> transitions;

		public void Awake()
		{
			DontDestroyOnLoad(this);
			if (!makeSingleton(this)) {
				Destroy(this);
			}
			DI_GameState.setTransitions(transitions);
		}

		public void OnEnable()
		{
			DI_EventCenter<int, DI_GameStateEvent>.addListener("OnRequestStateChange", handleStateChangeRequest);
		}

		public void OnDisable()
		{
			DI_EventCenter<int, DI_GameStateEvent>.removeListener("OnRequestStateChange", handleStateChangeRequest);
		}

		public void handleStateChangeRequest(int playerId, DI_GameStateEvent reason)
		{
			DI_GameStates nextState = DI_GameState.getTransition(DI_GameState.getGameStateForPlayer(playerId), reason);
			log (DI_DebugLevel.INFO, "A gamestate event has been raised, event: "
			     + Enum.GetName(typeof(DI_GameStateEvent), reason)
			     + " for the player: " + playerId
			     + " the players current state is: " + Enum.GetName(typeof(DI_GameStates), DI_GameState.getGameStateForPlayer(playerId))
			     + " the next step is: " + Enum.GetName(typeof(DI_GameStates), nextState)
			     );
			DI_GameState.transitionToState(playerId, nextState);
		}

		public void Update()
		{
			// Debug Section
			playerOneGameState = DI_GameState.getGameStateForPlayer(0);
			playerTwoGameState = DI_GameState.getGameStateForPlayer(1);
			//
		}
	}
}