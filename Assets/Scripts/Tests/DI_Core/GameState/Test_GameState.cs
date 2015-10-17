// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using System.Collections.Generic;
using DI.Test;
using DI.Core.GameState;
using DI.Core.Events;

namespace DI.Core.Test
{
	public class Test_GameState : DI_Test, DI_TestInterface
	{
		public List<DI_StateTransition> transitions;

		public Test_GameState(): base() {}
		
		public bool buildUp()
		{
			transitions = new List<DI_StateTransition>();
			transitions.Add(new DI_StateTransition(DI_GameStates.UNKNOWN, DI_GameStates.PLAYING, DI_GameStateEvent.ON_ENTER_PLAYING));
			transitions.Add(new DI_StateTransition(DI_GameStates.PLAYING, DI_GameStates.IN_DIALOG, DI_GameStateEvent.ON_ENTER_DIALOG));
			transitions.Add(new DI_StateTransition(DI_GameStates.IN_DIALOG, DI_GameStates.PLAYING, DI_GameStateEvent.ON_EXIT_DIALOG));
			DI_GameState.setTransitions(transitions);
			return true;
		}
		
		public DI_TestResult run()
		{
			isEqual(DI_GameState.getGameStateForPlayer(0), DI_GameStates.UNKNOWN, "Default gamestate is set to unknown.");

			// Note only the transitions between unknown -> playing, playing -> in dialog, in dialog -> playing are setup.
			DI_GameState.transitionToState(0, DI_GameState.getTransition(0, DI_GameStateEvent.ON_ENTER_PLAYING));
			isEqual(DI_GameState.getGameStateForPlayer(0), DI_GameStates.PLAYING, "Transitioning From UNKNOWN to PLAYING worked.");
			DI_GameState.transitionToState(0, DI_GameState.getTransition(0, DI_GameStateEvent.ON_ENTER_DIALOG));
			isEqual(DI_GameState.getGameStateForPlayer(0), DI_GameStates.IN_DIALOG, "Transitioning From PLAYING to IN DIALOG worked.");
			DI_GameState.transitionToState(0, DI_GameState.getTransition(0, DI_GameStateEvent.ON_EXIT_DIALOG));
			isEqual(DI_GameState.getGameStateForPlayer(0), DI_GameStates.PLAYING, "Transitioning From IN DIALOG to PLAYING works.");

			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			transitions = null;
			DI_GameState.setTransitions(transitions);
			return true;
		}
		
		public string getTestName() {
			return "Game State Test";
		}
	}
}