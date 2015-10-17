// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System.Collections.Generic;
using System;

using DI.Core.Debug;

namespace DI.Core.GameState
{
	public static class DI_GameState
	{
		private static List<DI_GameStates> gameStates = new List<DI_GameStates>();
		private static List<DI_StateTransition> transitions;

		public static void setTransitions(List<DI_StateTransition> states)
		{
			transitions = states;
		}

		public static DI_GameStates getTransition(DI_GameStates currentState, DI_GameStateEvent eventType)
		{
			if (transitions != null) {
				for (int iteration = 0; iteration < transitions.Count; iteration++) {
					if (transitions[iteration].thisState == currentState && transitions[iteration].transitionEvent == eventType) {
						DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Transition found: " 
						                  + Enum.GetName(typeof(DI_GameStates), currentState)
						                  + "-->" + Enum.GetName(typeof(DI_GameStates), transitions[iteration].nextState)
						                  );
						return transitions[iteration].nextState;
					}
				}
				DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Transition not found: " 
				                  + Enum.GetName(typeof(DI_GameStates), currentState)
				                  + "-->" + Enum.GetName(typeof(DI_GameStates), DI_GameStates.UNKNOWN)
				                  );
			}
			else {
				DI_Debug.writeLog(DI_DebugLevel.HIGH, "DI_GameState transitions are not set yet, but an attempt was made to access them.");
			}
			return DI_GameStates.UNKNOWN;
		}

		public static DI_GameStates getTransition(int playerId, DI_GameStateEvent eventType)
		{
			return getTransition(getGameStateForPlayer(playerId), eventType);
		}

		public static DI_GameStates getGameStateForPlayer(int playerId)
		{
			if (playerId >= gameStates.Count) {
				gameStates.Add(DI_GameStates.UNKNOWN);
			}
			return gameStates[playerId];
		}

		private static void setGamestateForPlayer(int playerId, DI_GameStates state)
		{
			if (playerId >= gameStates.Count) {
				gameStates.Add(state);
			}
			else {
				gameStates[playerId] = state;
			}
		}

		public static void transitionToState(int playerId, DI_GameStates state) {
			DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Transistioning from: "
			                  + Enum.GetName(typeof(DI_GameStates), getGameStateForPlayer(playerId))
			                  + " to " + Enum.GetName(typeof(DI_GameStates), state)
			                  + " for playerId: " + playerId);
			gameStates[playerId] = state;
		}
	}
}