// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;

namespace DI.Entities.Properties
{
	[Serializable]
	public struct DI_HealthProperty
	{
		public float maxHealth;
		public float currentHealth;
		public bool isImmortal;
		public bool isDead;
	}
}