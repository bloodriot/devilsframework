// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Test;
using DI.Core.Debug;
using DI.Entities.Player;

namespace DI.Entities.Test
{
	public class Test_PlayerEntity : DI_Test, DI_TestInterface
	{
		public Test_PlayerEntity(): base() {}
		
		public bool buildUp()
		{
			return true;
		}
		
		public DI_TestResult run()
		{
			DI_PlayerEntity entity = new DI_PlayerEntity();

			entity.setPlayerId(10);

			isEqual(entity.getPlayerId(), 10, "Setting / Getting the player id works.");
			
			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			return true;
		}
		
		public string getTestName() {
			return "Player Entity Test";
		}
	}
}