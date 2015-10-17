// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;

namespace DI.Core.GameState
{
	[Serializable]
	public class DI_StateTransition
	{
		public DI_GameStates thisState;
		public DI_GameStates nextState;
		public DI_GameStateEvent transitionEvent;

		public DI_StateTransition(DI_GameStates _thisState, DI_GameStates _nextState, DI_GameStateEvent _transitionEvent)
		{
			thisState = _thisState;
			nextState = _nextState;
			transitionEvent = _transitionEvent;
		}
	}
}