// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;
using System.Collections.Generic;

using DI.Core.Behaviours;

namespace DI.Core.Pooling
{
	[AddComponentMenu("Devil's Inc Studios/Managers/Pooling")]
	public class PoolManager : DI_MonoBehaviourSingleton<PoolManager>
	{
		public List<GameObject> prefabsToManage;

		public void Awake()
		{
			if (!makeSingleton(this)) {
				Destroy(this);
			}
		}

		public void OnEnable()
		{
			log(DI.Core.Debug.DI_DebugLevel.MEDIUM, "OnEnable: " + this.name);
			DI_PoolManager.reset();

			for (int objectId = 0; objectId < prefabsToManage.Count; objectId++) {
				DI_PoolManager.addObjectToManagedPool(prefabsToManage[objectId]);
			}
			DI_PoolManager.initalize();
		}
	}
}