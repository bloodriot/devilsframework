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
	public class MusicManager : DI_MonoBehaviour
	{
		[HideInInspector]
		public static MusicManager instance;

		[Header("Background Music Selection")]
		public List<DI_AudioTrack> backgroundMusic;

		[Header("Audio Source Setup")]
		public AudioSource audioSource;
		public AudioMixerSnapshot[] crossfadeSnapshots;

		[Header("General Settings")]
		public bool playOnStartup = false;
		public float masterBGMVolume = 0.25f;

		private bool isCrossFading = false;

		public void Awake()
		{
			if (instance == null) {
				instance = this;
			}
			else {
				log(DI_DebugLevel.INFO, "Attempted to create a new instance of a singleton class, cleaning up the duplicate.");
				Destroy(this);
			}
		}

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
					if (!isCrossFading) {
						if (DI_Music.currentlyPlaying.outroTime <= audioTrackTimeLeft) {
							DI_Music.crossFadeOut(crossfadeSnapshots);
							isCrossFading = true;
							StartCoroutine(crossFade(DI_Music.currentlyPlaying.outroTime));
						}
						if (DI_Music.currentlyPlaying.introTime >= audioSource.time) {
							DI_Music.crossFadeIn(crossfadeSnapshots);
							isCrossFading = true;
							StartCoroutine(crossFade(DI_Music.currentlyPlaying.introTime));
						}
					}
				}
			}
			else {
				DI_Music.playNextRandom();
				if (DI_Music.currentlyPlaying.shouldCrossFade) {
					StartCoroutine(crossFade(DI_Music.currentlyPlaying.introTime));
					isCrossFading = true;
				}
			}
		}

		public IEnumerator crossFade(float time)
		{
			yield return new WaitForSeconds(time);
			isCrossFading = false;
		}
	}
}