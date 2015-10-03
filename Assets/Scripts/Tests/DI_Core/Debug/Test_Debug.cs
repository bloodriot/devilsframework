// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using DI.Test;

namespace DI.Core.Test
{
	public class Test_Debug : DI_Test, DI_TestInterface
	{
		public Test_Debug(): base() {}

		public bool buildUp()
		{
			return true;
		}

		public void testLog()
		{
			DI_Debug.writeLog(DI_DebugLevel.ALL, "Test");
			DI_Debug.writeLog(DI_DebugLevel.INFO, "Test");
			DI_Debug.writeLog(DI_DebugLevel.LOW, "Test");
			DI_Debug.writeLog(DI_DebugLevel.MEDIUM, "Test");
			DI_Debug.writeLog(DI_DebugLevel.HIGH, "Test");
			DI_Debug.writeLog(DI_DebugLevel.CRITICAL, "Test");
		}

		public DI_TestResult run()
		{
			DI_Debug.setGobalDebugLevel(DI_DebugLevel.ALL);
			isEqual<DI_DebugLevel>(DI_DebugLevel.ALL, DI_Debug.getGlobalDebugLevel(), "Setting global debug works correctly.");

			testLog();
			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			return true;
		}
		
		public string getTestName() {
			return "Debug Test";
		}
	}
}