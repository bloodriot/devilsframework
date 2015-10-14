// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//
using System.Diagnostics;

namespace DI.Core.Debug
{
	public class DI_DebugLogEntry
	{
		public DI_DebugLevel logLevel;
		public StackTrace details;
		public string message;

		public DI_DebugLogEntry(DI_DebugLevel debugLevel, StackTrace stackFrame, string debugMessage)
		{
			logLevel = debugLevel;
			details = stackFrame;
			message = debugMessage;
		}
	}
}