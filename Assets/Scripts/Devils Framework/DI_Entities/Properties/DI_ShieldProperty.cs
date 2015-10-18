// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;
using System.Xml.Serialization;
using System.Xml;

namespace DI.Entities.Properties
{
	[Serializable]
	public struct DI_ShieldProperty
	{
		public float maxShield;
		public float currentShield;
		public float absorptionAmount;
	}
}