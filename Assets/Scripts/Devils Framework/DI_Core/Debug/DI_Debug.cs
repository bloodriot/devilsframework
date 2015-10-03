// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
// TODO: Include a description of the file here.
//

using UnityEngine;
using System.Diagnostics;
using System;

namespace DI.Core
{
	public static class DI_Debug
	{
		private static DI_DebugLevel globalDebugLevel = DI_DebugLevel.ALL;

		public static void setGobalDebugLevel(DI_DebugLevel debugLevel) {
			writeLog(DI_DebugLevel.INFO, "globalDebugLevel changed to: " + Enum.GetName(typeof(DI_DebugLevel), debugLevel));
			globalDebugLevel = debugLevel;
		}

		public static DI_DebugLevel getGlobalDebugLevel()
		{
			return globalDebugLevel;
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

				switch (debugLevel) {
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
			//#endif
		}
	}
}
