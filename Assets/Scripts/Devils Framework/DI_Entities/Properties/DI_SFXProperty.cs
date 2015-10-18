// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System.Collections.Generic;
using UnityEngine;
using System;

using DI.SFX;

namespace DI.Entities.Properties
{
	[Serializable]
	public struct DI_SFXProperty
	{
		public List<DI_SFXClipProperties> sfxs;
		public bool hasSFX;
	}
}