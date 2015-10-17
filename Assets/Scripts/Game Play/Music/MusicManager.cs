// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;
using System.Collections;

using DI.Core.Behaviours;
using DI.Core.Debug;

namespace DI.Music
{
	public class MusicManager : DI_MonoBehaviourSingleton<MusicManager>
	{
		[Header("Background Music Selection")]
		public List<DI_AudioTrack> backgroundMusic;

		[Header("Audio Source Setup")]
		public AudioSource audioSource;
		public AudioSource audioSourceTwo;
		[Tooltip("It's important to put the snapshots in the right order, Slient first then Normal.")]
		public AudioMixerSnapshot[] crossfadeSnapshots;

		[Header("General Settings")]
		public bool playOnStartup = false;
		public float masterBGMVolume = 0.25f;

		private bool isFading = false;

		public void OnEnable()
		{
			if (backgroundMusic != null) {
				for (int iteration = 0; iteration < backgroundMusic.Count; iteration++) {
					DI_Music.addAudioTrack(backgroundMusic[iteration]);
				}
			}

			DI_Music.setAudioSource(audioSource);

			if (playOnStartup) {
				DI_Music.playNextRandom();
			}

			audioSource.volume = masterBGMVolume;
		}

		public void Update()
		{
			if (audioSource.isPlaying) {
				float audioTrackTimeLeft = audioSource.clip.length - audioSource.time;
				if (DI_Music.currentlyPlaying.shouldCrossFade) {
					if (!isFading) {
						if (DI_Music.currentlyPlaying.outroTime <= audioTrackTimeLeft) {
							DI_Music.fadeOut(crossfadeSnapshots);
							isFading = true;
							StartCoroutine(fadeTimer(DI_Music.currentlyPlaying.outroTime));
						}
						if (DI_Music.currentlyPlaying.introTime >= audioSource.time) {
							DI_Music.fadeIn(crossfadeSnapshots);
							isFading = true;
							StartCoroutine(fadeTimer(DI_Music.currentlyPlaying.introTime));
						}
					}
				}
			}
			else {
				DI_Music.playNextRandom();
				if (DI_Music.currentlyPlaying.shouldCrossFade) {
					StartCoroutine(fadeTimer(DI_Music.currentlyPlaying.introTime));
					isFading = true;
				}
			}
		}

		public IEnumerator fadeTimer(float time)
		{
			yield return new WaitForSeconds(time);
			isFading = false;
		}
	}
}