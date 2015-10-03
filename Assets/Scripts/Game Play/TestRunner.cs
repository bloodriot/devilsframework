// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Core;
using DI.Test;

public class TestRunner : DI.Core.DI_MonoBehaviour
{
	public void Awake()
	{
		DI_TestRunner.runTests();
	}
}