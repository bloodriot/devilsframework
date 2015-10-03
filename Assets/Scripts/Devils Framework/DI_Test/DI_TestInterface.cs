// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

namespace DI.Test
{
	public interface DI_TestInterface
	{
		bool buildUp();
		DI_TestResult run();
		bool tearDown();
		string getTestName();
		int getTotalTests();
		int getPassedTests();
		int getFailedTests();
		DI_TestResult getTestResult();
	}
}