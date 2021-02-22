using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
	public AudioSource[] sounds;
	public AudioSource music;
	public bool DevMode;
	public TMP_Text dMode, sound, musics;
	public int m, s = 5;
	public Button sup, sdown, mup, mdown, on, off;
	public GameObject term, docs;
	
	void Awake()
	{
		ChangeValue("null");
		if (PlayerPrefs.GetInt("dev") == 1)
			DevMode = true;
		else
			DevMode = false;
		m = PlayerPrefs.GetInt("m");
		s = PlayerPrefs.GetInt("s");
		
		
		//music = GameObject.Find("_MusicSource").GetComponent<AudioSource>();
	}

	void Update()
	{
		musics.text = m.ToString();
		sound.text = s.ToString();
		if (m == 5)
		{
			music.volume = 1f;
		}
		if (m == 4)
		{
			music.volume = 0.8f;
		}
		if (m == 3)
		{
			music.volume = 0.6f;
		}
		if (m == 2)
		{
			music.volume = 0.4f;
		}
		if (m == 1)
		{
			music.volume = 0.2f;
		}
		if (m == 0)
		{
			music.volume = 0f;
		}
		if (s == 5)
		{
			for(int i = 0; i < sounds.Length; i++)
			{
				sounds[i].volume = 1f;
			}
		}
		if (s == 4)
		{
			for (int i = 0; i < sounds.Length; i++)
			{
				sounds[i].volume = 0.8f;
			}
		}
		if (s == 3)
		{
			for (int i = 0; i < sounds.Length; i++)
			{
				sounds[i].volume = 0.6f;
			}
		}
		if (s == 2)
		{
			for (int i = 0; i < sounds.Length; i++)
			{
				sounds[i].volume = 0.4f;
			}
		}
		if (s == 1)
		{
			for (int i = 0; i < sounds.Length; i++)
			{
				sounds[i].volume = 0.2f;
			}
		}
		if (s == 0)
		{
			for (int i = 0; i < sounds.Length; i++)
			{
				sounds[i].volume = 0f;
			}
		}
	}

	public void ChangeValue(string value)
	{
		if (value == "musicd")
		{
			if (m>0)
				m -= 1;

		}
		if (value == "soundd")
		{
			if (s > 0)
				s -= 1;
		}
		if (value == "false")
		{
			DevMode = false;
			dMode.text = "OFF";
			term.SetActive(false);
			docs.SetActive(false);
			PlayerPrefs.SetInt("dev", 0);
		}

		if (value == "musicu")
		{
			if (m < 5)
				m += 1;
		}
		if (value == "soundu")
		{
			if (s < 5)
				s += 1;
		}
		if (value == "true")
		{
			DevMode = true;
			dMode.text = "ON";
			term.SetActive(true);
			docs.SetActive(true);
			PlayerPrefs.SetInt("dev", 1);
		}
		PlayerPrefs.SetInt("m", m);
		PlayerPrefs.SetInt("s", s);

	}

}
