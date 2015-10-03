// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEditor;

namespace DI.Test
{
	public static class DI_TestRunnerEditor
	{
		[MenuItem("Devil's Inc Studios/Tests/Test Runner")]
		public static void startTests()
		{
			DI_TestRunner.runTests();
		}
	}
}