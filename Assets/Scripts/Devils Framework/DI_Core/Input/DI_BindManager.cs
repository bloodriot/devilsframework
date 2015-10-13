// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System;
using System.IO;
using DI.Core.Debug;

namespace DI.Core.Input
{
	public static class DI_BindManager
	{
		[XmlElement("Bindings")]
		public static DI_Bindings bindings;

		public static void loadBoundKeys()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(DI_Bindings));
			FileStream stream = new FileStream("Config/keybindings.xml", FileMode.Open);
			bindings = serializer.Deserialize(stream) as DI_Bindings;
			stream.Close();
		}

		public static void saveBoundKeys()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(DI_Bindings));
			FileStream stream = new FileStream("Config/keybindings.xml", FileMode.Create);
			serializer.Serialize(stream, bindings);
			stream.Close();
		}

		public static void printBinds()
		{
			DI_Debug.writeLog(DI_DebugLevel.CRITICAL, "BindManager: printBinds()");
			for (int playerId = 0; playerId < bindings.boundKeys.Count; playerId++) {
				DI_Debug.writeLog(DI_DebugLevel.CRITICAL, "BindManager: playerId: " + playerId);
				for (int iteration = 0; iteration < bindings.boundKeys.Count; iteration++) {
					DI_Debug.writeLog(DI_DebugLevel.CRITICAL, bindings.boundKeys[iteration].toString());
				}
			}
		}

		public static int getKeyIndex(string bindName, int playerId)
		{
			if (bindings == null) {
				DI_Debug.writeLog(DI_DebugLevel.HIGH, "Bound keys has not been set yet, but access was requested.");
				bindings = new DI_Bindings();
			}
			
			if (bindings.boundKeys.Count >= playerId) {
				for (int iteration = 0; iteration < bindings.boundKeys.Count; iteration++) {
					if (bindings.boundKeys[iteration].bindName == bindName) {
						return iteration;
					}
				}
			}
			return -1;
		}

		public static void setKey(DI_KeyBind keyBinding)
		{
			if (bindings == null) {
				DI_Debug.writeLog(DI_DebugLevel.HIGH, "Bound keys has not been set yet, but access was requested.");
				bindings = new DI_Bindings();
			}
			
			if (bindings.boundKeys.Count >= keyBinding.playerId) {
				int keyIndex = getKeyIndex(keyBinding.bindName, keyBinding.playerId);

				DI_Debug.writeLog(DI_DebugLevel.INFO, "Bind Manager: " + keyBinding.toString());
				if (keyIndex != -1) {
					bindings.boundKeys[keyIndex] = keyBinding;
				}
				else {
					bindings.boundKeys.Add(keyBinding);
				}
			}
		}

		public static string getKey(string bindName, int playerId)
		{
			if (bindings == null) {
				DI_Debug.writeLog(DI_DebugLevel.HIGH, "Bound keys has not been set yet, but access was requested.");
				bindings = new DI_Bindings();
			}

			if (bindings.boundKeys.Count >= playerId) {
				for (int iteration = 0; iteration < bindings.boundKeys.Count; iteration++) {
					if (bindings.boundKeys[iteration].bindName == bindName) {
						return bindings.boundKeys[iteration].bindKey;
					}
				}
			}
			return null;
		}

		public static DI_KeyBindType getBindType(string bindName, int playerId)
		{
			if (bindings == null) {
				DI_Debug.writeLog(DI_DebugLevel.HIGH, "Bound keys has not been set yet, but access was requested.");
				bindings = new DI_Bindings();
			}
			
			if (bindings.boundKeys.Count >= playerId) {
				for (int iteration = 0; iteration < bindings.boundKeys.Count; iteration++) {
					if (bindings.boundKeys[iteration].bindName == bindName) {
						return bindings.boundKeys[iteration].bindType;
					}
				}
			}
			return DI_KeyBindType.UNDEFINED;
		}


		public static void setBindType(string bindName, int playerId, DI_KeyBindType type)
		{
			if (bindings == null) {
				DI_Debug.writeLog(DI_DebugLevel.HIGH, "Bound keys has not been set yet, but access was requested.");
				bindings = new DI_Bindings();
			}

			int keyIndex = -1;

			if (bindings.boundKeys.Count >= playerId) {
				for (int iteration = 0; iteration < bindings.boundKeys.Count; iteration++) {
					if (bindings.boundKeys[iteration].bindName == bindName) {
						keyIndex = iteration;
					}
				}
			}

			if (keyIndex != -1) {
				DI_KeyBind bind = bindings.boundKeys[keyIndex];
				bind.bindType = type;
				bindings.boundKeys[keyIndex] = bind;
			}
		}
	}
}

