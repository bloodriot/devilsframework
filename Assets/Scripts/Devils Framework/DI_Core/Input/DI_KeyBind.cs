// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;
using System.Xml.Serialization;
using System.Xml;

namespace DI.Core.Input
{
	[Serializable]
	public class DI_KeyBind
	{
		[XmlAttribute("Bind Type")]
		public DI_KeyBindType bindType;
		[XmlAttribute("Bound Key")]
		public string bindKey;
		[XmlAttribute("Player Id")]
		public int playerId;
		[XmlAttribute("Bind Name")]
		public string bindName;
		[XmlAttribute("Dead Zone")]
		public float deadZone;

		public string toString()
		{
			return ("Name: " + bindName + " Type: " + bindType + " Key: " + bindKey + " Player Id: " + playerId);
		}

		public DI_KeyBind() {}
		public DI_KeyBind(string name, DI_KeyBindType type, string key, int player)
		{
			bindName = name;
			bindType = type;
			bindKey = key;
			playerId = player;
		}
	}
}