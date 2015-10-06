// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using System.Threading;
using DI.Test;
using DI.Core.Events;

namespace DI.Core.Test
{
	public class Test_EventCenter : DI_Test, DI_TestInterface
	{
		private bool noArgTestResult = false;
		private bool oneArgTestResult = false;
		private bool twoArgTestResult = false;
		private bool threeArgTestResult = false;
		private bool fourArgTestResult = false;

		public Test_EventCenter(): base() {}

		public void handleNoArgTest()
		{
			noArgTestResult = true;
		}

		public void handleOneArgTest(string arg)
		{
			if (arg == "Test") {
				oneArgTestResult = true;
			}
		}

		public void handleTwoArgTest(string argOne, string argTwo)
		{
			if (argOne == "Test" && argTwo == "Test") {
				twoArgTestResult = true;
			}
		}

		public void handleThreeArgTest(string argOne, string argTwo, string argThree)
		{
			if (argOne == "Test" && argTwo == "Test" && argThree == "Test") {
				threeArgTestResult = true;
			}
		}

		public void handleFourArgTest(string argOne, string argTwo, string argThree, string argFour)
		{
			if (argOne == "Test" && argTwo == "Test" && argThree == "Test" && argFour == "Test") {
				fourArgTestResult = true;
			}
		}

		public bool buildUp()
		{
			DI_EventCenter.addListener("onTestEventCenter", handleNoArgTest);
			DI_EventCenter<string>.addListener("onTestEventCenter", handleOneArgTest);
			DI_EventCenter<string, string>.addListener("onTestEventCenter", handleTwoArgTest);
			DI_EventCenter<string, string, string>.addListener("onTestEventCenter", handleThreeArgTest);
			DI_EventCenter<string, string, string, string>.addListener("onTestEventCenter", handleFourArgTest);
			return true;
		}

		public DI_TestResult run()
		{
			DI_EventCenter.invoke("onTestEventCenter");
			DI_EventCenter<string>.invoke("onTestEventCenter", "Test");
			DI_EventCenter<string, string>.invoke("onTestEventCenter", "Test", "Test");
			DI_EventCenter<string, string, string>.invoke("onTestEventCenter", "Test", "Test", "Test");
			DI_EventCenter<string, string, string, string>.invoke("onTestEventCenter", "Test", "Test", "Test", "Test");

			// Sleep 50ms to be sure that events have time to propagate.
			Thread.Sleep(50);

			isEqual<bool>(noArgTestResult, true, "EventCenter: noArgTest passed events correctly.");
			isEqual<bool>(oneArgTestResult, true, "EventCenter: oneArgTest passed events correctly.");
			isEqual<bool>(twoArgTestResult, true, "EventCenter: twoArgTest passed events correctly.");
			isEqual<bool>(threeArgTestResult, true, "EventCenter: threeArgTest passed events correctly.");
			isEqual<bool>(fourArgTestResult, true, "EventCenter: fourArgTest passed events correctly.");

			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			DI_EventCenter.removeListener("onTestEventCenter", handleNoArgTest);
			DI_EventCenter<string>.removeListener("onTestEventCenter", handleOneArgTest);
			DI_EventCenter<string, string>.removeListener("onTestEventCenter", handleTwoArgTest);
			DI_EventCenter<string, string, string>.removeListener("onTestEventCenter", handleThreeArgTest);
			DI_EventCenter<string, string, string, string>.removeListener("onTestEventCenter", handleFourArgTest);

			return true;
		}
		
		public string getTestName() {
			return "EventCenter Test";
		}
	}
}