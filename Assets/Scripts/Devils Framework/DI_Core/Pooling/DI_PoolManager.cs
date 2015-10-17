// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;
using System.Collections.Generic;
using System;
using DI.Core.Helpers;
using DI.Core.Debug;

namespace DI.Core.Pooling
{
	public static class DI_PoolManager
	{
		public static List<GameObject> managedPrefabs;
		public static bool willGrow = true;
		public static int startingSize = 1;
		private static Dictionary<string, List<GameObject>> poolContents;
		private static bool isInitalized = false;
		private static GameObject pooledObjectsContainer;

		public static void reset()
		{
			DI_Debug.writeLog(DI_DebugLevel.INFO, "DI_PoolManager: Reset");
			isInitalized = false;
			if (Application.isEditor) {
				GameObject.DestroyImmediate(pooledObjectsContainer);
			}
			else {
				GameObject.Destroy(pooledObjectsContainer);
			}
			managedPrefabs = new List<GameObject>();
			poolContents = new Dictionary<string, List<GameObject>>();

		}

		public static void initalize()
		{
			if (!isInitalized) {
				DI_Debug.writeLog(DI_DebugLevel.INFO, "DI_PoolManager: Initalize");
				poolContents = new Dictionary<string, List<GameObject>>();

				if (managedPrefabs == null) {
					managedPrefabs = new List<GameObject>();
				}

				pooledObjectsContainer = DI_ObjectHelper.createGameObject("Pooled Objects");

				Debug.DI_Debug.writeLog(DI.Core.Debug.DI_DebugLevel.MEDIUM, "DI_PoolManager: managedPrefabs Count:" + managedPrefabs.Count);
				for (int prefabIndex = 0; prefabIndex < managedPrefabs.Count; prefabIndex++) {
					for (int index = 0; index < startingSize; index++) {
						string key = managedPrefabs[prefabIndex].name;
						Debug.DI_Debug.writeLog(DI.Core.Debug.DI_DebugLevel.MEDIUM, "DI_PoolManager: key:" + key);
						
						if (!poolContents.ContainsKey(key)) {
							List<GameObject> objectPool = new List<GameObject>();
							poolContents.Add(key, objectPool);
							DI_ObjectHelper.createGameObject("Pool Members - " + key, pooledObjectsContainer);
						}

						GameObject tempObject = (GameObject)GameObject.Instantiate(managedPrefabs[prefabIndex]);
						tempObject.SetActive(false);
						tempObject.transform.parent = pooledObjectsContainer.transform.GetChild(prefabIndex);

						poolContents[key].Add(tempObject);
					}
				}
				isInitalized = true;
			}
		}

		public static void setWillGrow(bool grow)
		{
			willGrow = grow;
		}

		public static void setStartingSize(int size)
		{
			startingSize = size;
		}

		public static int getStartingSize()
		{
			return startingSize;
		}

		public static GameObject getPrefabByName(string name)
		{
			DI_Debug.writeLog(DI_DebugLevel.INFO, "DI_PoolManager: getPrefabByName(" + name + ")");
			for (int index = 0; index < managedPrefabs.Count; ++index) {
				if (managedPrefabs[index].name == name) {
					return managedPrefabs[index];
				}
			}
			return null;
		}
		
		public static int getPrefabId(GameObject prefab)
		{
			DI_Debug.writeLog(DI_DebugLevel.INFO, "DI_PoolManager: getPrefabId(" + prefab.name + ")");
			if (managedPrefabs.Contains(prefab)) {
				for (int index = 0; index < managedPrefabs.Count; ++index) {
					if (managedPrefabs[index] == prefab) {
						return index;
					}
				}
			}
			return 0;
		}

		public static GameObject getPooledObject(string type)
		{
			DI_Debug.writeLog(DI_DebugLevel.INFO, "DI_PoolManager: getPooledObject(" + type + ")");

			if (!isInitalized) {
				initalize();
			}

			if (poolContents.ContainsKey(type)) {
				// We found an object we can use, return it.
				for (int index = 0; index < poolContents[type].Count; ++index) {
					if (poolContents[type][index] != null) {
						if (!poolContents[type][index].activeInHierarchy) {
							return poolContents[type][index];
						}
					}
				}
				// We are out of pooled objects to use, spawn more if we can.
				if (willGrow) {
					GameObject prefab = getPrefabByName(type);
					if (prefab != null) {
						GameObject tempObject = (GameObject)GameObject.Instantiate(prefab);
						tempObject.SetActive(false);
						tempObject.transform.parent = pooledObjectsContainer.transform.GetChild(getPrefabId(prefab));
						poolContents[prefab.name].Add(tempObject);
						return tempObject;
					}
					else {
						throw new Exception("A non-managed item is being requested from the pool manager - Item Requested: " + type);
					}
				}
				
				// We couldn't grow and we didn't have any left return null.
				return null;
			}
			
			// A non managed object is being requested.
			throw new Exception("A non-managed item is being requested from the pool manager - Item Requested: " + type);
		}

		public static void addObjectToManagedPool(GameObject prefab)
		{
			DI_Debug.writeLog(DI_DebugLevel.INFO, "DI_PoolManager: addObjectToManagedPool(" + prefab.name + ")");
			if (managedPrefabs == null) {
				managedPrefabs = new List<GameObject>();
			}

			if (!managedPrefabs.Contains(prefab)) {
				DI_Debug.writeLog(DI_DebugLevel.INFO, "DI_PoolManager: addObjectToManagedPool(" + prefab.name + "): Added prefab to managed list.");
				managedPrefabs.Add(prefab);
			}
		}

		public static void removeObjectFromManagedPool(GameObject prefab)
		{
			DI_Debug.writeLog(DI_DebugLevel.INFO, "DI_PoolManager: removeObjectFromManagedPool(" + prefab.name + ")");
			if (managedPrefabs == null) {
				managedPrefabs = new List<GameObject>();
			}
			else {
				if (managedPrefabs.Contains(prefab)) {
					if (getPrefabId(prefab) != 0) {
						if (pooledObjectsContainer.transform.GetChild(getPrefabId(prefab)) != null) {
							if (Application.isEditor) {
								GameObject.DestroyImmediate(pooledObjectsContainer.transform.GetChild(getPrefabId(prefab)));
							}
							else {
								GameObject.Destroy(pooledObjectsContainer.transform.GetChild(getPrefabId(prefab)));
							}
						}
					}
					managedPrefabs.Remove(prefab);
				}
			}
		}
	}
}