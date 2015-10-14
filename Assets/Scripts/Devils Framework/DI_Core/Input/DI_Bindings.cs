// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using DI.Core.Debug;
using System;

namespace DI.Core.Input
{
	[Serializable]
	public class DI_Bindings
	{
		[XmlArray("Player")]
		[XmlArrayItem("Bound Keys")]
		public List<List<DI_KeyBind>> boundKeys;

		public DI_Bindings()
		{
			boundKeys = new List<List<DI_KeyBind>>();
		}
	}
}