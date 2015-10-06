// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using System;
using DI.Test;
using DI.Core.Helpers;

namespace DI.Core.Test
{
	public class Test_World : DI_Test, DI_TestInterface
	{

		public Test_World(): base() {}
		
		public bool buildUp()
		{
			return true;
		}
		
		public DI_TestResult run()
		{
			isEqual<float>(DI_World.convertTimeToSunAngle(12, 0), 90.0f, "Sun angle at noon is 90 degrees");
			isEqual<float>(DI_World.convertTimeToSunAngle(0, 0), 270.0f, "Sun angle at 12am is 270 degrees");
			isEqual<float>(DI_World.convertTimeToSunAngle(6, 0), 360.0f, "Sun angle at 6am is 0 degrees");

			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			return true;
		}
		
		public string getTestName() {
			return "World Helper Test";
		}
	}
}