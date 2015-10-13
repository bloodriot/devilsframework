// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using System;
using DI.Test;
using DI.Core.Input;

namespace DI.Core.Test
{
	public class Test_Input : DI_Test, DI_TestInterface
	{
		
		public Test_Input(): base() {}
		
		public bool buildUp()
		{
			DI_BindManager.bindings = null;
			return true;
		}
		
		public DI_TestResult run()
		{
			DI_KeyBind forward = new DI_KeyBind("forward", DI_KeyBindType.BIND_KEY, "w", 0);
			DI_BindManager.setKey(forward);
			DI_BindManager.saveBoundKeys();

			isEqual(DI_BindManager.getKeyIndex("forward", 0), 0, "Fetching the key index from a known bind returns the correct index value.");
			DI_BindManager.bindings = null;
			DI_BindManager.loadBoundKeys();
			isEqual(DI_BindManager.getKeyIndex("forward", 0), 0, "Loading a known bind from the config file returns a correct index value.");
			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			DI_BindManager.bindings = null;
			return true;
		}
		
		public string getTestName() {
			return "Input Bindings Test";
		}
	}
}