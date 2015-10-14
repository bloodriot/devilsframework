// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using UnityEngine;
using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace DI.Core.Debug
{
	public static class DI_Debug
	{
		private static bool logToUnity = false;
		private static bool logToCustom = true;

		private static DI_DebugLevel globalDebugLevel = DI_DebugLevel.ALL;
		public static List<DI_DebugLogEntry> debugLog;
		public static void setGobalDebugLevel(DI_DebugLevel debugLevel) {
			writeLog(DI_DebugLevel.INFO, "globalDebugLevel changed to: " + Enum.GetName(typeof(DI_DebugLevel), debugLevel));
			globalDebugLevel = debugLevel;
		}


		public static void setUnityLogging(bool shouldLog)
		{
			logToUnity = shouldLog;
		}

		public static void setCustomLogging(bool shouldLog)
		{
			logToCustom = shouldLog;
		}

		public static DI_DebugLevel getGlobalDebugLevel()
		{
			return globalDebugLevel;
		}

		public static Color getDebugLevelColor(DI_DebugLevel level)
		{
			switch (level) {
				case DI_DebugLevel.ALL:
					return Color.black;
				case DI_DebugLevel.ENGINE:
					return Color.grey;
				case DI_DebugLevel.INFO:
					return new Color(0.15f, 0.15f, 0.55f);
				case DI_DebugLevel.LOW:
					return Color.blue;
				case DI_DebugLevel.MEDIUM:
					return new Color(0.2F, 0.3F, 0.4F);
				case DI_DebugLevel.HIGH:
					return Color.red;
				case DI_DebugLevel.CRITICAL:
					return new Color(0.25f, 0.0f, 0.0f);
				default:
					return Color.green;
			}
		}

		public static bool debugLevelEnabled(DI_DebugLevel level)
		{
			return (level >= globalDebugLevel);
		}

		//Todo replace the unity console with our own stuff.
		public static void writeLog(DI_DebugLevel debugLevel, string message)
		{
			// writeLog does nothing if #DEBUG is not enabled.

			//#if DEBUG
			if (debugLevel >= globalDebugLevel) {

				// Pull up the stack data so we know what is calling our logging function.
				StackTrace stackTrace = new StackTrace(false);
				StackFrame stackFrame = stackTrace.GetFrame(1);

				string prefix = "[" + Enum.GetName(typeof(DI_DebugLevel), debugLevel) + ": "
					+ stackFrame.GetFileName() + ":"
					+ stackFrame.GetFileLineNumber() + "] ";

				// Log entries should be prefixed like such: [<DEBUG LEVEL> FileName:LINE Time]
				if (debugLog == null) {
					debugLog = new List<DI_DebugLogEntry>();
				}

				if (logToCustom) {
					debugLog.Add(new DI_DebugLogEntry(debugLevel, stackTrace, prefix + message));
				}

				if (logToUnity) {
					switch (debugLevel) {
						case DI_DebugLevel.ALL:
							UnityEngine.Debug.Log(prefix + message);
						break;
						case DI_DebugLevel.ENGINE:
							UnityEngine.Debug.Log(prefix + message);
						break;
						case DI_DebugLevel.INFO:
							UnityEngine.Debug.Log(prefix + message);
						break;
						case DI_DebugLevel.LOW:
							UnityEngine.Debug.Log(prefix + message);
						break;
						case DI_DebugLevel.MEDIUM:
							UnityEngine.Debug.LogWarning(prefix + message);
						break;
						case DI_DebugLevel.HIGH:
							UnityEngine.Debug.LogError(prefix + message);
						break;
						case DI_DebugLevel.CRITICAL:
							UnityEngine.Debug.LogError(prefix + message);
						break;
					}
				}
			}
			//#endif
		}
	}
}
