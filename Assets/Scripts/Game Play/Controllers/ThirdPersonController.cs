// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;

using DI.Core.Debug;
using DI.Core.Events;
using DI.Core.Behaviours;
using DI.Entities.Properties;
using DI.Core.Input;
using DI.Core.GameState;
using DI.SFX;
using DI.Core;

namespace DI.Controllers
{
	public class ThirdPersonController : DI_MonoBehaviour
	{
		public DI_CharacterProperties characterProperties;

		private float movementAudioDelay = 0.0f;
		public float verticalMovementSpeed = 0.0f;
		public float horizontalMovementSpeed = 0.0f;
		public Vector3 moveDirection;

		private int walkKeyIndex = 0;
		private int horizontalKeyIndex = 0;
		private int verticalKeyIndex = 0;
		private int jumpKeyIndex = 0;
		private int sprintKeyIndex = 0;

		public void disablePlayerControl()
		{
			characterProperties.isInControl = false;
		}
		
		public void enablePlayerControl()
		{
			characterProperties.isInControl = true;
		}

		private void playFootSteps(float timeDelta)
		{
			if (characterProperties.playMovementSounds) {
				if (movementAudioDelay >= characterProperties.movementSoundInterval) {
					if (characterProperties.movementSounds.hasSFX) {
						DI_SFX.playClipAtPoint(transform.position, characterProperties.movementSounds.sfxs[Random.Range(0, characterProperties.movementSounds.sfxs.Count)]);
						movementAudioDelay = 0.0f;
					}
				}
				movementAudioDelay = Mathf.Clamp(movementAudioDelay + DI_Time.getTimeDelta(), 0, characterProperties.movementSoundInterval);
			}
		}
		
		//################################################################################################
		public void OnEnable()
		{
			updateKeyCache();
		}

		public void updateKeyCache()
		{
			walkKeyIndex = DI_BindManager.getKeyIndex("Walk", characterProperties.getPlayerId());
			horizontalKeyIndex = DI_BindManager.getKeyIndex("Horizontal", characterProperties.getPlayerId());
			verticalKeyIndex = DI_BindManager.getKeyIndex("Vertical", characterProperties.getPlayerId());
			jumpKeyIndex = DI_BindManager.getKeyIndex("Jump", characterProperties.getPlayerId());
			sprintKeyIndex = DI_BindManager.getKeyIndex("Sprint", characterProperties.getPlayerId());
		}

		public void LateUpdate()
		{
			if (horizontalKeyIndex == -1) {
				updateKeyCache();
			}

			// Disable the player if we are in a state other than playing.
			if (DI_GameState.getGameStateForPlayer(characterProperties.getPlayerId()) != DI_GameStates.PLAYING) {
				disablePlayerControl();
			}
			else {
				enablePlayerControl();
			}

			if (characterProperties.isInControl) {
				if (characterProperties.isGrounded) {
					switch (DI_BindManager.getKeyState(verticalKeyIndex, characterProperties.getPlayerId())) {
					case DI_KeyState.AXIS_POSITIVE:
						characterProperties.verticalMovement = 1.0f;
						break;
					case DI_KeyState.AXIS_NOT_PRESSED:
						characterProperties.verticalMovement = 0.0f;
						break;
					case DI_KeyState.AXIS_NEGATIVE:
						characterProperties.verticalMovement = -1.0f;
						break;
					}

					switch (DI_BindManager.getKeyState(horizontalKeyIndex, characterProperties.getPlayerId())) {
					case DI_KeyState.AXIS_POSITIVE:
						characterProperties.horizontalMovement = 1.0f;
						break;
					case DI_KeyState.AXIS_NOT_PRESSED:
						characterProperties.horizontalMovement = 0.0f;
						break;
					case DI_KeyState.AXIS_NEGATIVE:
						characterProperties.horizontalMovement = -1.0f;
						break;
					}

					if (DI_BindManager.getKeyState(walkKeyIndex, characterProperties.getPlayerId()) == DI_KeyState.KEY_HELD) {
						verticalMovementSpeed = Mathf.Clamp(characterProperties.verticalMovement * characterProperties.getMaxMovementSpeed(), -1 * characterProperties.getMaxMovementSpeed(), characterProperties.getMaxMovementSpeed());
						horizontalMovementSpeed = Mathf.Clamp(characterProperties.horizontalMovement * characterProperties.sprintSpeedSettings.maxMovementSpeed, -1 * characterProperties.sprintSpeedSettings.maxMovementSpeed, characterProperties.sprintSpeedSettings.maxMovementSpeed);
					}
					else if (DI_BindManager.getKeyState(sprintKeyIndex, characterProperties.getPlayerId()) == DI_KeyState.KEY_HELD) {
						verticalMovementSpeed = Mathf.Clamp(characterProperties.verticalMovement * characterProperties.sprintSpeedSettings.maxMovementSpeed, -1 * characterProperties.sprintSpeedSettings.maxMovementSpeed, characterProperties.sprintSpeedSettings.maxMovementSpeed);
						horizontalMovementSpeed = Mathf.Clamp(characterProperties.horizontalMovement * characterProperties.sprintSpeedSettings.maxMovementSpeed, -1 * characterProperties.sprintSpeedSettings.maxMovementSpeed, characterProperties.sprintSpeedSettings.maxMovementSpeed);
					}
					else {
						verticalMovementSpeed = Mathf.Clamp(characterProperties.verticalMovement * characterProperties.runSpeedSettings.maxMovementSpeed, -1 * characterProperties.runSpeedSettings.maxMovementSpeed, characterProperties.runSpeedSettings.maxMovementSpeed);
						horizontalMovementSpeed = Mathf.Clamp(characterProperties.horizontalMovement * characterProperties.runSpeedSettings.maxMovementSpeed, -1 * characterProperties.runSpeedSettings.maxMovementSpeed, characterProperties.runSpeedSettings.maxMovementSpeed);
					}
					Vector3 directionVector = new Vector3(horizontalMovementSpeed, 0, verticalMovementSpeed);
					moveDirection = transform.rotation * directionVector;
				}
				moveDirection.y = (Physics.gravity.y * characterProperties.jumpGravityMultiplier) * DI_Time.getTimeDelta();
				characterProperties.controller.Move(moveDirection * DI_Time.getTimeDelta());


				playFootSteps(DI_Time.getTimeDelta());
			}

			if (!characterProperties.isInControl && Input.GetKey(KeyCode.Escape)) {
				DI_GameState.transitionToState(characterProperties.getPlayerId(), DI_GameStates.PLAYING);
			}
		}

		public void FixedUpdate()
		{
			RaycastHit hit;
			Ray ray = new Ray(transform.position, Vector3.down);
			Debug.DrawRay(transform.position, Vector3.down, Color.red);
			if (Physics.Raycast(ray, out hit)) {
				characterProperties.distanceFromGround = hit.distance;
				if (hit.distance > characterProperties.groundFudge) {
					characterProperties.isGrounded = false;
				}
				else {
					characterProperties.isGrounded = true;
				}
			}
		}
	}
}