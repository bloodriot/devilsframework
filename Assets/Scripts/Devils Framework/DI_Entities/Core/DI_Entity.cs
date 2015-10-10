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

namespace DI.Entities.Core
{
	public class DI_Entity
	{
		private System.Guid entityId;
		public DI_AnimationProperty animationProperties;
		public DI_MovementProperty movementProperties;
		public DI_SFXProperty sfxPropertiesOnSpawn;
		public DI_SFXProperty sfxPropertiesOnDespawn;
		public DI_HealthProperty healthProperties;

		public void addSpawnSFX(DI_SFXClip clip)
		{
			if (!sfxPropertiesOnSpawn.sfxs.Contains(clip)) {
				sfxPropertiesOnSpawn.sfxs.Add(clip);
			}
		}

		public void removeSpawnSFX(DI_SFXClip clip)
		{
			if (sfxPropertiesOnSpawn.sfxs.Contains(clip)) {
				sfxPropertiesOnSpawn.sfxs.Remove(clip);
			}
		}

		// On Despawn Sound Effects
		public void addDespawnSFX(DI_SFXClip clip)
		{
			if (!sfxPropertiesOnDespawn.sfxs.Contains(clip)) {
				sfxPropertiesOnDespawn.sfxs.Add(clip);
			}
		}
		
		public void removeDespawnSFX(DI_SFXClip clip)
		{
			if (sfxPropertiesOnDespawn.sfxs.Contains(clip)) {
				sfxPropertiesOnDespawn.sfxs.Remove(clip);
			}
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

		// This will need to be implimented in game play code as we don't have a GameObject to take the transform.position from.
		public virtual void playSFX(DI_SFXProperty sfxProperty) {}

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