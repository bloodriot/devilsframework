// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Entities.Properties;
using DI.Core.Events;
using DI.Core.Debug;
using DI.SFX;

using UnityEngine;
using System;

namespace DI.Entities.Core
{
	[Serializable]
	public class DI_Entity
	{
		protected System.Guid entityId;

		[Header("Entity Properties")]
		[SerializeField]
		protected DI_AnimationProperty animationProperties;
		[SerializeField]
		protected DI_MovementProperty movementProperties;
		[SerializeField]
		protected DI_HealthProperty healthProperties;

		[Header("Entity Sound FX Properties")]
		[SerializeField]
		protected DI_SFXProperty sfxPropertiesOnSpawn;
		[SerializeField]
		protected DI_SFXProperty sfxPropertiesOnDespawn;

		[Header("Entity Settings")]
		[SerializeField]
		protected GameObject entityBody;

		public void addSpawnSFX(DI_SFXClipProperties clip)
		{
			if (!sfxPropertiesOnSpawn.sfxs.Contains(clip)) {
				sfxPropertiesOnSpawn.sfxs.Add(clip);
			}
		}

		public void removeSpawnSFX(DI_SFXClipProperties clip)
		{
			if (sfxPropertiesOnSpawn.sfxs.Contains(clip)) {
				sfxPropertiesOnSpawn.sfxs.Remove(clip);
			}
		}

		// On Despawn Sound Effects
		public void addDespawnSFX(DI_SFXClipProperties clip)
		{
			if (!sfxPropertiesOnDespawn.sfxs.Contains(clip)) {
				sfxPropertiesOnDespawn.sfxs.Add(clip);
			}
		}
		
		public void removeDespawnSFX(DI_SFXClipProperties clip)
		{
			if (sfxPropertiesOnDespawn.sfxs.Contains(clip)) {
				sfxPropertiesOnDespawn.sfxs.Remove(clip);
			}
		}

		public bool hasAnimations()
		{
			return animationProperties.hasAnimations;
		}
		public Animator getAnimator()
		{
			return animationProperties.animator;
		}

		// Health Property
		public void setHealth(float newHealth)
		{
			healthProperties.currentHealth = newHealth;
		}

		public float getHealth()
		{
			return healthProperties.currentHealth;
		}

		public void setMaxHealth(float newHealth)
		{
			healthProperties.maxHealth = newHealth;
		}

		public float getMaxHealth()
		{
			return healthProperties.maxHealth;
		}

		// Movement Property
		public void setMovementSpeed(float newSpeed)
		{
			movementProperties.movementSpeed = newSpeed;
		}

		public float getMovementSpeed()
		{
			return movementProperties.movementSpeed;
		}

		public void setMaxMovementSpeedRunning(float newSpeed)
		{
			movementProperties.maxMovementSpeedRunning = newSpeed;
		}
		
		public float getMaxMovementSpeedRunning()
		{
			return movementProperties.maxMovementSpeedRunning;
		}

		public void setMovementSpeedIncreaseRate(float newSpeed)
		{
			movementProperties.movementSpeedIncreaseRate = newSpeed;
		}
		
		public float getMovementSpeedIncreaseRate()
		{
			return movementProperties.movementSpeedIncreaseRate;
		}

		public void setMaxMovementSpeed(float newSpeed)
		{
			movementProperties.maxMovementSpeed = newSpeed;
		}

		public float getMaxMovementSpeed()
		{
			return movementProperties.maxMovementSpeed;
		}

		public void setTurnSpeed(float newSpeed)
		{
			movementProperties.turnSpeed = newSpeed;
		}

		public float getTurnSpeed()
		{
			return movementProperties.turnSpeed;
		}

		public void setMaxTurnSpeed(float newSpeed)
		{
			movementProperties.maxTurnSpeed = newSpeed;
		}

		public float getMaxTurnSpeed()
		{
			return movementProperties.maxTurnSpeed;
		}

		public void setTurnSpeedIncreaseRate(float newSpeed)
		{
			movementProperties.turnSpeedIncreaseRate = newSpeed;
		}
		
		public float getTurnSpeedIncreaseRate()
		{
			return movementProperties.turnSpeedIncreaseRate;
		}

		public void setEntityBody(GameObject body)
		{
			entityBody = body;
		}

		public GameObject getEntityBody()
		{
			return entityBody;
		}

		public void playSFX(DI_SFXClipProperties sfxProperty) {
			if (entityBody != null) {
				DI_SFX.playClipAtPoint(entityBody.transform.position, sfxProperty);
			}
			else {
				DI_Debug.writeLog(DI_DebugLevel.HIGH, "Attempted to play an sfx at point without a location.");
			}
		}

		// We don't know what the entity looks like, does it need armor reset, animations?
		// The class that inherits this will need to set all this in its overriden onSpawn().
		public virtual void resetEntity() {}

		// This lets you keep track of the individual instance (life) of an entity.
		public System.Guid getEntityId()
		{
			return entityId;
		}

		// Entity logic
		public void onDespawn()
		{
			DI_EventCenter<DI_Entity>.invoke("OnDespawn", this);
			DI_Debug.writeLog(DI_DebugLevel.LOW, "Entity onDespawn(" + this.entityId.ToString() + ")");
		}

		public void onSpawn()
		{
			entityId = System.Guid.NewGuid();
			DI_EventCenter<DI_Entity>.invoke("OnSpawn", this);
			DI_Debug.writeLog(DI_DebugLevel.LOW, "Entity onSpawn(" + this.entityId.ToString() + ")");
		}
	}
}