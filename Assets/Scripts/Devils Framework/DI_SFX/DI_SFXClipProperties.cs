// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using UnityEngine;
using UnityEngine.Audio;
using System;
namespace DI.SFX
{
	[Serializable]
	public struct DI_SFXClipProperties
	{
		public AudioClip clip;
		public float maxDistance;
		public float minDistance;
		public float volume;
		public float pitch;
		public AudioMixerGroup audioGroup;
	}
}