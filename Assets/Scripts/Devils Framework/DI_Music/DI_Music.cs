// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;
using UnityEngine.Audio;

using System.Collections;
using System.Collections.Generic;

using DI.Core.Debug;

namespace DI.Music
{
	public static class DI_Music
	{
		private static AudioSource source;

		private static List<DI_AudioTrack> audioTracks;
		public static DI_AudioTrack currentlyPlaying;

		private static List<DI_AudioTrack> availableTracks;

		private static void rebuildPlaylist()
		{
			availableTracks = new List<DI_AudioTrack>();
			for (int iteration = 0; iteration < audioTracks.Count; ++iteration) {
				if (audioTracks[iteration].clip != currentlyPlaying.clip) {
					availableTracks.Add(audioTracks[iteration]);
				}
			}
		}

		private static void crossFade()
		{
			if (currentlyPlaying.shouldCrossFade) {
			}
		}

		public static void addAudioTrack(DI_AudioTrack track)
		{
			if (audioTracks == null) {
				audioTracks = new List<DI_AudioTrack>();
			}

			if (!audioTracks.Contains(track)) {
				audioTracks.Add(track);
				rebuildPlaylist();
			}
		}

		public static void playNext()
		{
			if (availableTracks.Count == 0) {
				rebuildPlaylist();
			}

			currentlyPlaying = availableTracks[0];
			availableTracks.RemoveAt(0);

			play();
		}

		public static void playNextRandom()
		{
			if (availableTracks.Count == 0) {
				rebuildPlaylist();
			}

			int trackNumber = UnityEngine.Random.Range(0, availableTracks.Count);
			currentlyPlaying = availableTracks[trackNumber];
			availableTracks.RemoveAt(trackNumber);

			play();
		}

		public static void crossFadeIn(AudioMixerSnapshot[] snapshots)
		{
			source.outputAudioMixerGroup.audioMixer.TransitionToSnapshots(snapshots, new float[] {0.0f, 1.0f}, currentlyPlaying.introTime);
		}

		public static void crossFadeOut(AudioMixerSnapshot[] snapshots)
		{
			source.outputAudioMixerGroup.audioMixer.TransitionToSnapshots(snapshots, new float[] {0.0f, 1.0f}, currentlyPlaying.outroTime);
		}

		public static void play()
		{
			if (source != null) {
				source.clip = currentlyPlaying.clip;
				source.Play();
			}
			else {
				DI_Debug.writeLog(DI_DebugLevel.CRITICAL, "AudioSource is not yet defined, yet attempting to play an audio clip with it.");
			}
		}

		public static void playTrack(DI_AudioTrack audioTrack)
		{
			currentlyPlaying = audioTrack;
			play ();
		}

		public static void setAudioSource(AudioSource input)
		{
			source = input;
		}
	}
}