// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Core;

namespace DI.Test
{
	public class DI_Test
	{
		protected int totalTests = 0;
		protected int passedTests = 0;
		protected int failedTests = 0;

		public int getTotalTests() { return totalTests; }
		public int getPassedTests() { return passedTests; }
		public int getFailedTests() { return failedTests; }
		public DI_TestResult getTestResult() { return new DI_TestResult(passedTests, failedTests, totalTests); }

		public bool isEqual<T>(T objectOne, T objectTwo, string description)
		{
			totalTests++;
			if (objectOne.Equals(objectTwo)) {
				passedTests++;
				DI_Debug.writeLog(DI_DebugLevel.INFO, "Test: " + description + " Result: true");
				return true;
			}
			else {
				failedTests++;
				DI_Debug.writeLog(DI_DebugLevel.INFO, "Test: " + description + " Result: false");
				return false;
			}
		}
		public bool isNotEqual<T>(T objectOne, T objectTwo, string description)
		{
			totalTests++;
			if (!objectOne.Equals(objectTwo)) {
				passedTests++;
				DI_Debug.writeLog(DI_DebugLevel.INFO, "Test: " + description + " Result: true");
				return true;
			}
			else {
				failedTests++;
				DI_Debug.writeLog(DI_DebugLevel.INFO, "Test: " + description + " Result: false");
				return false;
			}
		}
	}
}