// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using System;
using DI.Test;
using DI.Core.Pooling;
using UnityEngine;

namespace DI.Core.Test
{
	public class Test_Pooling : DI_Test, DI_TestInterface
	{

		public GameObject goOne;
		public GameObject goTwo;
		public GameObject goThree;
		public GameObject goFour;
		public GameObject goFive;

		public Test_Pooling(): base() {}
		
		public bool buildUp()
		{
			DI_PoolManager.reset();

			goOne = new GameObject("Test Object One");
			goTwo = new GameObject("Test Object Two");
			goThree = new GameObject("Test Object Three");
			goFour = new GameObject("Test Object Four");
			goFive = new GameObject("Test Object Five");

			DI_PoolManager.addObjectToManagedPool(goOne);
			DI_PoolManager.addObjectToManagedPool(goTwo);
			DI_PoolManager.addObjectToManagedPool(goThree);
			DI_PoolManager.addObjectToManagedPool(goFour);
			DI_PoolManager.addObjectToManagedPool(goFive);
			return true;
		}
		
		public DI_TestResult run()
		{
			DI_PoolManager.setStartingSize(10);
			DI_PoolManager.setWillGrow(true);
			DI_PoolManager.initalize();

			isEqual<bool>((DI_PoolManager.getPrefabByName("Test Object One") == null), false, "Adding an object to pool management and fetching it works. 1/5");
			isEqual<bool>((DI_PoolManager.getPrefabByName("Test Object Two") == null), false, "Adding an object to pool management and fetching it works. 2/5");
			isEqual<bool>((DI_PoolManager.getPrefabByName("Test Object Three") == null), false, "Adding an object to pool management and fetching it works. 3/5");
			isEqual<bool>((DI_PoolManager.getPrefabByName("Test Object Four") == null), false, "Adding an object to pool management and fetching it works. 4/5");
			isEqual<bool>((DI_PoolManager.getPrefabByName("Test Object Five") == null), false, "Adding an object to pool management and fetching it works. 5/5");
			isEqual<int>(DI_PoolManager.getPrefabId(goOne), 0, "Fetching prefabId from item One returns 0");
			isEqual<int>(DI_PoolManager.getPrefabId(goTwo), 1, "Fetching prefabId from item Two returns 1");
			isEqual<int>(DI_PoolManager.getPrefabId(goThree), 2, "Fetching prefabId from item Three returns 2");
			isEqual<int>(DI_PoolManager.getPrefabId(goFour), 3, "Fetching prefabId from item Four returns 3");
			isEqual<int>(DI_PoolManager.getPrefabId(goFive), 4, "Fetching prefabId from item Five returns 4");

			return new DI_TestResult(passedTests, failedTests, totalTests);
		}
		
		public bool tearDown()
		{
			DI_PoolManager.removeObjectFromManagedPool(goOne);
			DI_PoolManager.removeObjectFromManagedPool(goTwo);
			DI_PoolManager.removeObjectFromManagedPool(goThree);
			DI_PoolManager.removeObjectFromManagedPool(goFour);
			DI_PoolManager.removeObjectFromManagedPool(goFive);

			GameObject.DestroyImmediate(goOne);
			GameObject.DestroyImmediate(goTwo);
			GameObject.DestroyImmediate(goThree);
			GameObject.DestroyImmediate(goFour);
			GameObject.DestroyImmediate(goFive);

			DI_PoolManager.reset();
			return true;
		}
		
		public string getTestName() {
			return "Pool Manager Test";
		}
	}
}