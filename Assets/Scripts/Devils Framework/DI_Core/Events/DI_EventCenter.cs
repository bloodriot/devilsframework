// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using System.Collections.Generic;
using System.Collections;
using System;
using System.Diagnostics;
using DI.Core.Debug;

namespace DI.Core.Events
{
	class DI_EventCenter {
		static public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();
		
		static public void addListener(string eventType, CallBack callback) {
			
			lock (eventTable) {
				// Make sure we aren't adding delegate and null.
				if (!eventTable.ContainsKey(eventType)) {
					eventTable.Add(eventType, null);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Adding listener for event type: " + eventType);
				}
				
				// Add the call back to the list of delgates
				eventTable[eventType] = (CallBack)eventTable[eventType] + callback;
			}
		}
		
		static public void removeListener(string eventType, CallBack callback) {
			lock (eventTable) {
				if (eventTable.ContainsKey(eventType)) {
					eventTable[eventType] = (CallBack)eventTable[eventType] - callback;
					
					if (eventTable[eventType] == null) {
						eventTable.Remove(eventType);
						DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Removing listener for event type: " + eventType);
					}
				}
			}
		}
		
		static public void invoke(string eventType) {
			Delegate handler;
			if (eventTable.TryGetValue(eventType, out handler)) {
				CallBack callback = (CallBack)handler;
				if (callback != null) {
					callback();
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Invoke called for event type: " + eventType);
				}
			}
		}
	}
	
	class DI_EventCenter<T> {
		static public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();
		
		static public void addListener(string eventType, CallBack<T> callback) {
			
			lock (eventTable) {
				// Make sure we aren't adding delegate and null.
				if (!eventTable.ContainsKey(eventType)) {
					eventTable.Add(eventType, null);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Adding listener for event type: " + eventType);
				}
				
				// Add the call back to the list of delgates
				eventTable[eventType] = (CallBack<T>)eventTable[eventType] + callback;
			}
		}
		static public void removeListener(string eventType, CallBack<T> callback) {
			lock (eventTable) {
				if (eventTable.ContainsKey(eventType)) {
					eventTable[eventType] = (CallBack<T>)eventTable[eventType] - callback;
					
					if (eventTable[eventType] == null) {
						eventTable.Remove(eventType);
						DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Removing listener for event type: " + eventType);
					}
				}
			}
		}
		
		static public void invoke(string eventType, T argv1) {
			Delegate handler;
			if (eventTable.TryGetValue(eventType, out handler)) {
				CallBack<T> callback = (CallBack<T>)handler;
				if (callback != null) {
					callback(argv1);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Invoke called for event type: " + eventType);
				}
			}
		}
	}
	
	class DI_EventCenter<T, U> {
		static public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();
		
		static public void addListener(string eventType, CallBack<T, U> callback) {
			
			lock (eventTable) {
				// Make sure we aren't adding delegate and null.
				if (!eventTable.ContainsKey(eventType)) {
					eventTable.Add(eventType, null);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Adding listener for event type: " + eventType);
				}
				
				// Add the call back to the list of delgates
				eventTable[eventType] = (CallBack<T, U>)eventTable[eventType] + callback;
			}
		}
		static public void removeListener(string eventType, CallBack<T, U> callback) {
			lock (eventTable) {
				if (eventTable.ContainsKey(eventType)) {
					eventTable[eventType] = (CallBack<T, U>)eventTable[eventType] - callback;
					
					if (eventTable[eventType] == null) {
						eventTable.Remove(eventType);
						DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Removing listener for event type: " + eventType);
					}
				}
			}
		}
		
		static public void invoke(string eventType, T argv1, U argv2) {
			Delegate handler;
			if (eventTable.TryGetValue(eventType, out handler)) {
				CallBack<T, U> callback = (CallBack<T, U>)handler;
				if (callback != null) {
					callback(argv1, argv2);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Invoke called for event type: " + eventType);
				}
			}
		}
	}
	
	class DI_EventCenter<T, U, V> {
		static public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();
		
		static public void addListener(string eventType, CallBack<T, U, V> callback) {
			
			lock (eventTable) {
				// Make sure we aren't adding delegate and null.
				if (!eventTable.ContainsKey(eventType)) {
					eventTable.Add(eventType, null);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Adding listener for event type: " + eventType);
				}
				
				// Add the call back to the list of delgates
				eventTable[eventType] = (CallBack<T, U, V>)eventTable[eventType] + callback;
			}
		}
		static public void removeListener(string eventType, CallBack<T, U, V> callback) {
			lock (eventTable) {
				if (eventTable.ContainsKey(eventType)) {
					eventTable[eventType] = (CallBack<T, U, V>)eventTable[eventType] - callback;
					
					if (eventTable[eventType] == null) {
						eventTable.Remove(eventType);
						DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Removing listener for event type: " + eventType);
					}
				}
			}
		}
		
		static public void invoke(string eventType, T argv1, U argv2, V argv3) {
			Delegate handler;
			if (eventTable.TryGetValue(eventType, out handler)) {
				CallBack<T, U, V> callback = (CallBack<T, U, V>)handler;
				if (callback != null) {
					callback(argv1, argv2, argv3);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Invoke called for event type: " + eventType);
				}
			}
		}
	}
	
	class DI_EventCenter<T, U, V, W> {
		static public Dictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();
		
		static public void addListener(string eventType, CallBack<T, U, V, W> callback) {
			
			lock (eventTable) {
				// Make sure we aren't adding delegate and null.
				if (!eventTable.ContainsKey(eventType)) {
					eventTable.Add(eventType, null);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Adding listener for event type: " + eventType);
				}
				
				// Add the call back to the list of delgates
				eventTable[eventType] = (CallBack<T, U, V, W>)eventTable[eventType] + callback;
			}
		}
		static public void removeListener(string eventType, CallBack<T, U, V, W> callback) {
			lock (eventTable) {
				if (eventTable.ContainsKey(eventType)) {
					eventTable[eventType] = (CallBack<T, U, V, W>)eventTable[eventType] - callback;
					
					if (eventTable[eventType] == null) {
						eventTable.Remove(eventType);
						DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Removing listener for event type: " + eventType);
					}
				}
			}
		}
		
		static public void invoke(string eventType, T argv1, U argv2, V argv3, W argv4) {
			Delegate handler;
			if (eventTable.TryGetValue(eventType, out handler)) {
				CallBack<T, U, V, W> callback = (CallBack<T, U, V, W>)handler;
				if (callback != null) {
					callback(argv1, argv2, argv3, argv4);
					DI_Debug.writeLog(DI_DebugLevel.ENGINE, "Invoke called for event type: " + eventType);
				}
			}
		}
	}

	public delegate void CallBack();
	public delegate void CallBack<T>(T argv1);
	public delegate void CallBack<T, U>(T argv1, U argv2);
	public delegate void CallBack<T, U, V>(T argv1, U argv2, V argv3);
	public delegate void CallBack<T, U, V, W>(T argv1, U argv2, V argv3, W argv4);
}