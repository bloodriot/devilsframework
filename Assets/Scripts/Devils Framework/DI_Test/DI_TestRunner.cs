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

			for (int iteration = 0; iteration < types.Length; iteration++) {
				Type testType = types[iteration];
				Type[] interfaces = testType.GetInterfaces();
				for (int interfacesIteration = 0; interfacesIteration < interfaces.Length; interfacesIteration++) {
					Type interfaceType = interfaces[interfacesIteration];
					if (interfaceType == typeof(DI_TestInterface)) {
						DI_Debug.writeLog(DI_DebugLevel.MEDIUM, "Found a test to load: " + typeof(DI_TestInterface).ToString());
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

		public static bool runTest(int testId)
		{
			DateTime startTime = DateTime.Now;

			bool testPassed = true;

			// All tests impliment the DI_TestInterface interface.
			// The setups for running a test are:
			// 1. Build up the test.
			// 2. Run the test.
			// 3. Tear down the test.

			if (tests[testId].buildUp()) {
				if (tests[testId].run()) {
					if (!tests[testId].tearDown())
					{
						testPassed = false;
					}
				}
				else {
					testPassed = false;
				}
			}
			else {
				testPassed = false;
			}

			DateTime endTime = DateTime.Now;

			double testTime = DI_DateTime.diffTime(startTime, endTime).TotalMilliseconds;

			DI_Debug.writeLog(DI_DebugLevel.INFO, 
			                  " Test Name: " + tests[testId].getTestName()
			                  + " Result: " + testPassed.ToString()
			                  + " Time Taken: " + testTime + "MS");
			return true;
		}

		public static void runTests()
		{
			UnityEngine.Debug.Log("Starting Test Runner.");

			int failedTests = 0;
			int passedTests = 0;

			tests = new List<DI_TestInterface>();

			DateTime startTime = DateTime.Now;

			spawnTests();

			for (int testIteration = 0; testIteration < tests.Count; testIteration++) {
				if (runTest(testIteration)) {
					passedTests++;
				}
				else {
					failedTests++;
				}
			}

			DateTime endTime = DateTime.Now;

			DI_Debug.writeLog(DI_DebugLevel.INFO, 
			                  "Tests Ran: " + tests.Count
			                  + " Passed: " + passedTests
			                  + " Failed: " + failedTests
			                  + " Total Time Taken: " + DI_DateTime.diffTime(startTime, endTime).TotalMilliseconds + "MS");
		}
	}
}