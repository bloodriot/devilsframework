// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System.Collections.Generic;
using System.Reflection;
using System;

using DI.Core;

namespace DI.Test
{
	public static class DI_TestRunner
	{
		private static List<DI_TestInterface> tests;

		public static void spawnTests()
		{
			DateTime startTime = DateTime.Now;

			Type[] types = Assembly.GetExecutingAssembly().GetTypes();

			// Look at the assembly and loop through all the loaded classes.
			// Then look at the interfaces that class uses, if its using the testing interface then we found a test to load.
			// Create a new instance with the Activator and add it to the list of tests.

			for (int iteration = 0; iteration < types.Length; iteration++) {
				Type testType = types[iteration];
				Type[] interfaces = testType.GetInterfaces();
				for (int interfacesIteration = 0; interfacesIteration < interfaces.Length; interfacesIteration++) {
					Type interfaceType = interfaces[interfacesIteration];
					if (interfaceType == typeof(DI_TestInterface)) {
						DI_Debug.writeLog(DI_DebugLevel.INFO, "Found a test to load: " + typeof(DI_TestInterface).ToString());
						DI_TestInterface test = (DI_TestInterface) Activator.CreateInstance(types[iteration]);
						tests.Add(test);
					}
				}
			}

			DateTime endTime = DateTime.Now;
			
			double testTime = DI_DateTime.diffTime(startTime, endTime).TotalMilliseconds;
			
			DI_Debug.writeLog(DI_DebugLevel.INFO, 
			                  " Tests Loaded: " + tests.Count
			                  + " Time Taken: " + testTime + "MS");
		}

		public static DI_TestResult runTest(int testId)
		{
			DateTime startTime = DateTime.Now;

			bool testPassed = true;

			// All tests impliment the DI_TestInterface interface.
			// The setups for running a test are:
			// 1. Build up the test.
			// 2. Run the test.
			// 3. Tear down the test.

			DI_TestInterface test = tests[testId];
			test.buildUp();
			test.run();
			test.tearDown();

			DateTime endTime = DateTime.Now;

			double testTime = DI_DateTime.diffTime(startTime, endTime).TotalMilliseconds;

			DI_Debug.writeLog(DI_DebugLevel.INFO, 
			                  " Test Name: " + tests[testId].getTestName()
			                  + " Result: " + testPassed.ToString()
			                  + " Time Taken: " + testTime + "MS");
			return test.getTestResult();
		}

		public static void runTests()
		{
			DI_Debug.writeLog(DI_DebugLevel.INFO, "Starting Test Runner.");

			int failedTests = 0;
			int passedTests = 0;
			int totalTests = 0;

			tests = new List<DI_TestInterface>();

			DateTime startTime = DateTime.Now;

			spawnTests();

			for (int testIteration = 0; testIteration < tests.Count; testIteration++) {

				DateTime testStartTime = DateTime.Now;

				DI_TestInterface test = tests[testIteration];
				DI_TestResult results = runTest(testIteration);

				DateTime testEndTime = DateTime.Now;

				DI_Debug.writeLog(DI_DebugLevel.INFO,
				                  "Test Finished: " + test.getTestName()
				                  + " Sub Tests: " + results.totalTests
				                  + " Passed: " + results.passedTests
				                  + " Failed: " + results.failedTests
				                  + " Time Taken: " + DI_DateTime.diffTime(testStartTime, testEndTime).TotalMilliseconds + "MS");

				totalTests += results.totalTests;
				failedTests += results.failedTests;
				passedTests += results.passedTests;
			}

			DateTime endTime = DateTime.Now;

			DI_Debug.writeLog(DI_DebugLevel.INFO, 
			                  "Tests Found: " + tests.Count
			                  + " Sub Tests Ran: " + totalTests
			                  + " Passed: " + passedTests
			                  + " Failed: " + failedTests
			                  + " Total Time Taken: " + DI_DateTime.diffTime(startTime, endTime).TotalMilliseconds + "MS");
		}
	}
}