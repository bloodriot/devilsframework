// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Entities.Properties;
using DI.Core.Events;
using DI.Core.Debug;
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

		// On Spawn Sound Effects
		public void setSpawnSFXVolume(float volume)
		{
			sfxPropertiesOnSpawn.soundEffectVolume = volume;
		}

		public float getSpawnSFXVolume()
		{
			return sfxPropertiesOnSpawn.soundEffectVolume;
		}

		public void addSpawnSFX(AudioClip clip)
		{
			if (!sfxPropertiesOnSpawn.soundEffects.Contains(clip)) {
				sfxPropertiesOnSpawn.soundEffects.Add(clip);
			}
		}

		public void removeSpawnSFX(AudioClip clip)
		{
			if (sfxPropertiesOnSpawn.soundEffects.Contains(clip)) {
				sfxPropertiesOnSpawn.soundEffects.Remove(clip);
			}
		}

		// On Despawn Sound Effects
		public void setDespawnSFXVolume(float volume)
		{
			sfxPropertiesOnDespawn.soundEffectVolume = volume;
		}

		public float getDespawnSFXVolume()
		{
			return sfxPropertiesOnDespawn.soundEffectVolume;
		}
		
		public void addDespawnSFX(AudioClip clip)
		{
			if (!sfxPropertiesOnDespawn.soundEffects.Contains(clip)) {
				sfxPropertiesOnDespawn.soundEffects.Add(clip);
			}
		}
		
		public void removeDespawnSFX(AudioClip clip)
		{
			if (sfxPropertiesOnDespawn.soundEffects.Contains(clip)) {
				sfxPropertiesOnDespawn.soundEffects.Remove(clip);
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

		// Entity logic
		public void onDespawn()
		{
			DI_EventCenter<DI_Entity>.invoke("OnDespawn", this);
			DI_Debug.writeLog(DI_DebugLevel.LOW, "Entity onDespawn(" + this.entityId.ToString() + ")");
			if (sfxPropertiesOnDespawn.hasSFX) {
				// Play SFX
			}
		}

		public void onSpawn()
		{
			entityId = System.Guid.NewGuid();
			DI_EventCenter<DI_Entity>.invoke("OnSpawn", this);
			DI_Debug.writeLog(DI_DebugLevel.LOW, "Entity onSpawn(" + this.entityId.ToString() + ")");
			if (sfxPropertiesOnSpawn.hasSFX) {
				// Play SFX
			}
		}
	}
}