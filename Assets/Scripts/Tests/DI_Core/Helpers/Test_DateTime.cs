// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using System;
using DI.Test;

namespace DI.Core.Test
{
	public class Test_DateTime : DI_Test, DI_TestInterface
	{
		DateTime startDate;
		DateTime endDate;

		public Test_DateTime(): base() {}
		
		public bool buildUp()
		{
			startDate = new DateTime(2000, 1, 1, 0, 0, 0);
			endDate = new DateTime(2000, 1, 1, 0, 0, 3);
			return true;
		}
				
		public DI_TestResult run()
		{
			double timeDiff = DI_DateTime.diffTime(startDate, endDate).TotalMilliseconds;

			isEqual<double>(timeDiff, (double)3000, "diffDate time returns correct time.");

			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			return true;
		}
		
		public string getTestName() {
			return "Date Time Test";
		}
	}
}