// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using DI.Test;
using DI.Core.Debug;
using DI.Entities.Core;

namespace DI.Entities.Test
{
	public class Test_Entities : DI_Test, DI_TestInterface
	{
		public Test_Entities(): base() {}
		
		public bool buildUp()
		{
			return true;
		}

		public DI_TestResult run()
		{
			DI_Entity entity = new DI_Entity();

			entity.setHealth(100.0f);
			entity.setMaxHealth(100.0f);
			entity.setMovementSpeed(100.0f);
			entity.setMaxMovementSpeed(100.0f);
			entity.setTurnSpeed(100.0f);
			entity.setMaxTurnSpeed(100.0f);

			isEqual(entity.getHealth(), 100.0f, "Setting / Getting an Entities health works.");
			isEqual(entity.getMaxHealth(), 100.0f, "Setting / Getting an Entities max health works.");
			isEqual(entity.getMovementSpeed(), 100.0f, "Setting / Getting an Entities movement speed works.");
			isEqual(entity.getMaxMovementSpeed(), 100.0f, "Setting / Getting an Entities max movement speed works.");
			isEqual(entity.getTurnSpeed(), 100.0f, "Setting / Getting an Entities turn speed works.");
			isEqual(entity.getMaxTurnSpeed(), 100.0f, "Setting / Getting an Entities max turn speed works.");

			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			return true;
		}
		
		public string getTestName() {
			return "Entities Test";
		}
	}
}