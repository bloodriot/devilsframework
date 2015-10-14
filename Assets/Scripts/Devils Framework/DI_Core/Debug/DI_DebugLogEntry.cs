// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//
using System.Diagnostics;
using System.Xml.Serialization;
using System;

namespace DI.Core.Debug
{
	[Serializable]
	public class DI_DebugLogEntry
	{
		[XmlElement("Debug Level")]
		public DI_DebugLevel logLevel;
		[XmlElement("Stack Trace")]
		public StackTrace details;
		[XmlElement("Debug Message")]
		public string message;

		public DI_DebugLogEntry(DI_DebugLevel debugLevel, StackTrace stackFrame, string debugMessage)
		{
			logLevel = debugLevel;
			details = stackFrame;
			message = debugMessage;
		}
	}
}