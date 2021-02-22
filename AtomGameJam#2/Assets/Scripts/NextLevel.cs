using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

	public int levelIndex;
	public int next, hk;
	JENNA jn;
	public AudioSource src;
	public Console cs;
	bool l9;

	void Awake()
	{
		src = GameObject.Find("_AudioSource (2)").GetComponent<AudioSource>();
		jn = GameObject.Find("Jenna").GetComponent<JENNA>();
		cs = GameObject.Find("Monitor").transform.GetChild(0).GetComponent<Console>();
		if (levelIndex == 1)
		{
			hk = 2;
			cs.first = hk;
			cs.hak = hk;
		}
		if (levelIndex == 2)
		{
			hk = 1;
			cs.first = hk;
			cs.hak = hk;
		}
		if (levelIndex == 3)
		{
			hk = 1;
			cs.first = hk;
			cs.hak = hk;
		}
		if (levelIndex == 4)
		{
			hk = 1;
			cs.first = hk;
			cs.hak = hk;
		}
		if (levelIndex == 5)
		{
			hk = 2;
			cs.first = hk;
			cs.hak = hk;
		}
		if (levelIndex == 6)
		{
			hk = 2;
			cs.first = hk;
			cs.hak = hk;
		}
		if (levelIndex == 7)
		{
			hk = 2;
			cs.first = hk;
			cs.hak = hk;
		}
		if (levelIndex == 8)
		{
			hk = 2;
			cs.first = hk;
			cs.hak = hk;
		}
		if (levelIndex == 9)
		{
			hk = 1;
			cs.first = hk;
			cs.hak = hk;
			l9 = true;
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (levelIndex == 8)
			{
				Application.Quit();
			}
			else if (!l9)
			{
				StartCoroutine(Wait());
			}
			if (l9)
			{
				GetComponent<BoxCollider>().enabled = false;
				jn.timerc = jn.timer;
				jn.Play(16);
				jn.soundp[16] = true;
				l9 = false;
				return;
			}
		}
	}
	
	IEnumerator Wait()
	{
		src.Play();
		jn.timer = jn.times[next];
		jn.levels[levelIndex] = false;
		jn.restarted = false;
		yield return new WaitForSeconds(2);
		jn.levels[next] = true;
		jn.vscript.audioSource.Stop();
		SceneManager.LoadScene(next);
	}

}
