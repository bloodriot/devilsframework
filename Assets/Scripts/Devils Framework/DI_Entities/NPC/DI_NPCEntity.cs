// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Entities.Core;
using UnityEngine;

namespace DI.Entities.NPC
{
	public class DI_NPCEntity : DI_Entity
	{
		[SerializeField]
		protected string npcType;
		// Fall alseep, preventing code execution if we are to far away from a player.
		// You could override the onSleep method to despawn enemies that get to far away.
		[Header("Sleep settings")]
		[TooltipAttribute("Can this npc go to sleep")]
		[SerializeField]
		protected bool canSleep = true;
		protected bool isSleeping = false;
		// How close does a player need to be for us to be active.
		[TooltipAttribute("How close does a player need to be for this npc to remain awake")]
		[SerializeField]
		protected float activeRange = 100.0f;
		// How long should we wait between sleep checks.
		[TooltipAttribute("How often should this npc check for players in range")]
		[SerializeField]
		protected float sleepCheckTime = 1.0f;
		protected float lastSleepCheck = 0.0f;

		public void setNPCType(string type)
		{
			npcType = type;
		}

		public string getNPCType()
		{
			return npcType;
		}

		public void sleep()
		{
			if (canSleep) {
				isSleeping = true;
				OnSleep();
			}
		}

		public void wakeUp()
		{
			isSleeping = false;
			OnWakeUp();
		}

		public bool isAsleep()
		{
			return isSleeping;
		}

		public void sleepCheck()
		{
			if (canSleep) {
				if (lastSleepCheck >= sleepCheckTime) {
					if (playersInRange() > 0) {
						if (isSleeping) {
							wakeUp();
						}
					}
					else {
						if (!isSleeping) {
							sleep();
						}
					}
					lastSleepCheck = 0.0f;
				}
				else {
					lastSleepCheck += DI.Core.DI_Time.getTimeDelta();
				}
			}
		}

		public int playersInRange()
		{
			// This needs to be implimented still.
			if (activeRange > 0.0f) {
			}
			return 0;
		}

		public virtual void OnWakeUp()
		{
		}
		
		public virtual void OnSleep()
		{
		}

	}
}