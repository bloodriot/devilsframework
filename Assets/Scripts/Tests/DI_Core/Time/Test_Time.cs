// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using System;
using DI.Test;
using System.Threading;

namespace DI.Core.Test
{
	public class Test_Time : DI_Test, DI_TestInterface
	{
		
		public Test_Time(): base() {}
		
		public bool buildUp()
		{
			return true;
		}
		
		public DI_TestResult run()
		{
			DI_Time.setTimeMultipler(1.0f);
			isEqual(DI_Time.getTimeMultipler(), 1.0f, "Setting a time multipler and fetching it back works correctly 1/2.");

			DI_Time.setTimeMultipler(0.0f);
			isEqual(DI_Time.getTimeMultipler(), 0.0f, "Setting a time multipler and fetching it back works correctly 2/2.");

			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			DI_Time.setTimeMultipler(1.0f);
			return true;
		}
		
		public string getTestName() {
			return "Time Wrapper Test";
		}
	}
}