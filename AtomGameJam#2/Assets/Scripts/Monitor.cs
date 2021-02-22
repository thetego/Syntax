using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{

	public GameObject settings, console, docs, credits, play;
	public Animator anim;
	public JENNA jn;
	public bool first;

	public void Awake()
	{
		first = true;
		if (!jn.restarted)
		{
			Time.timeScale = 0;
		}
		
	}

	public void Update()
	{
		if (!first)
		{
			Time.timeScale = 1;
		}
	}
	public void Play()
	{
		Time.timeScale = 1;
		play.SetActive(false);
		settings.SetActive(false);
		console.SetActive(false);
		docs.SetActive(false);
		if (first)
		{
			anim.Play("menu back", -1, 0.0f);
			jn.Play(0);
			jn.soundp[0] = true;
			first = false;
		}


	}
	public void Settings()
	{
		settings.SetActive(true);
		console.SetActive(false);
		docs.SetActive(false);
		credits.SetActive(false);
		play.SetActive(false);
	}
	public void Credits()
	{
		settings.SetActive(false);
		console.SetActive(false);
		docs.SetActive(false);
		credits.SetActive(true);
		play.SetActive(false);
	}
	public void Console()
	{
		settings.SetActive(false);
		console.SetActive(true);
		docs.SetActive(false);
		credits.SetActive(false);
		play.SetActive(false);
	}
	public void Documents()
	{
		settings.SetActive(false);
		console.SetActive(false);
		docs.SetActive(true);
		credits.SetActive(false);
		play.SetActive(false);
	}
	public void Quit()
	{
		Application.Quit();
	}
	public void Back()
	{
		if (first)
		{
			play.SetActive(true);
		}
		settings.SetActive(false);
		console.SetActive(false);
		docs.SetActive(false);
		credits.SetActive(false);
		//play.SetActive(false);
		
	}
	public void site()
	{
		Application.OpenURL("https://opulencedev.com/");
	}
}
