// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;

namespace DI.SFX
{
	public static class DI_SFX
	{
		public static Transform parentObject;

		public static void playClipAtPoint(Vector3 point, DI_SFXClipProperties sfx)
		{
			if (parentObject == null) {
				parentObject = GameObject.Find("Audio").transform;
			}

			GameObject audioClip = new GameObject("Audio SFX - " + sfx.clip.name);
			audioClip.transform.parent = parentObject;
			AudioSource source = audioClip.AddComponent<AudioSource>();
			source.clip = sfx.clip;
			source.outputAudioMixerGroup = sfx.audioGroup;
			source.volume = sfx.volume;
			audioClip.transform.position = point;
			source.minDistance = sfx.minDistance;
			source.maxDistance = sfx.maxDistance;
			source.pitch = sfx.pitch;
			source.Play();
			UnityEngine.Object.Destroy(audioClip, sfx.clip.length);
		}
	}
}