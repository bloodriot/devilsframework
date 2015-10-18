// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using System;
using System.Collections.Generic;
using UnityEngine;

using DI.Entities.Properties;
using DI.Entities.Player;

namespace DI.Controllers
{
	[Serializable]
	public class DI_CharacterProperties : DI_PlayerEntity
	{
		[Header("Controller Settings.")]
		public CharacterController controller;
		[Header("Jump Settings.")]
		public bool canJump = false;
		public float jumpGravityMultiplier = 1.0f;
		public float jumpStrength = 0.0f;
		[Header("Run/Sprint Settings.")]
		public DI_RunSpeedProperty runSpeedSettings;
		public DI_RunSpeedProperty sprintSpeedSettings;
		public DI_StaminaProperty staminaSettings;
		[Header("Controller State Settings.")]
		public bool isWalking = false;
		public bool isSprinting = false;
		public bool isIdle = true;
		public bool isJumping = false;
		public bool isInControl = true;
		[Header("Ground Detection Settings.")]
		public float distanceFromGround = 0.0f;
		public bool isGrounded = false;
		public float groundFudge = 0.6f;
		[Header("Movement Sounds")]
		public bool playMovementSounds = false;
		public float movementSoundInterval = 0.3f;
		public DI_SFXProperty movementSounds;
		[Header("Debug View: Input Cache")]
		public float verticalMovement = 0.0f;
		public float horizontalMovement = 0.0f;
	}
}