// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

namespace DI.Test
{
	public class DI_TestResult
	{
		public int passedTests;
		public int failedTests;
		public int totalTests;
		
		public DI_TestResult(int passed, int failed, int total) {
			passedTests = passed;
			failedTests = failed;
			totalTests = total;
		}
	}
}