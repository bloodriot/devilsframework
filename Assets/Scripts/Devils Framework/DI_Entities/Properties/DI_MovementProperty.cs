// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;

namespace DI.Entities.Properties
{
	[Serializable]
	public struct DI_MovementProperty
	{
		public float maxMovementSpeed;
		public float maxMovementSpeedRunning;
		public float movementSpeedIncreaseRate;
		public float maxTurnSpeed;
		public float turnSpeedIncreaseRate;
		public float movementSpeed;
		public float turnSpeed;
		public bool canMove;
	}
}