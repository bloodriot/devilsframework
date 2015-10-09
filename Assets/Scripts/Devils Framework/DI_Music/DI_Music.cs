// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using DI.Core.Debug;

namespace DI.Music
{
	public static class DI_Music
	{
		public static AudioSource sourceOne;
		public static AudioSource sourceTwo;

		public static List<DI_AudioTrack> audioTracks;
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

			int trackNumber = UnityEngine.Random.Range(0, availableTracks.Count - 1);
			currentlyPlaying = availableTracks[trackNumber];
			availableTracks.RemoveAt(trackNumber);

			play();
		}

		public static void play()
		{
			if (sourceOne != null) {
				if (currentlyPlaying.shouldCrossFade) {
					crossFade();
				}
				else {
					sourceOne.clip = currentlyPlaying.clip;
					sourceOne.Play();
				}
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

		public static void setAudioSources(AudioSource sourceA, AudioSource sourceB)
		{
			sourceOne = sourceA;
			sourceTwo = sourceB;
		}
	}
}