using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubtitlesAndVoices
{
	public AudioSource clip;
	public string sub;

	public SubtitlesAndVoices(AudioSource _clip, string _sub)
	{
		clip = _clip;
		sub = _sub;
	}

}
