using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JENNA : MonoBehaviour
{
	public List<SubtitlesAndVoices> clip = new List<SubtitlesAndVoices>();
	static bool created = false;
	public VisualizerScript vscript;
	public TMP_Text subtitle;
	public float timer;
	public bool[] soundp;
	public bool[] levels;
	public bool restarted;
	public float timerc;
	public int[] times;
	public Vector3 startPos;
	public Monitor set;
	

	void Awake()
	{
		if (created)
		{
			Destroy(this.gameObject);
		}
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
		}
		

		vscript = GameObject.Find("Monitor (JENNA)").GetComponent<VisualizerScript>();

		

	}
	void Start()
	{
		
	}
	void Update()
	{
		if (levels[2])
		{
			startPos = new Vector3(-0.06f, -1.24f, 8.942495f);
			transform.position = startPos;
		}
		if (levels[3])
		{
			startPos = new Vector3(-1.9f, -2.5f, 8.5f);
			transform.position = startPos;
		}
		if (levels[4])
		{
			startPos = new Vector3(-1.72f, 0.4f, 8.942495f);
			transform.position = startPos;
		}
		if (levels[5])
		{
			startPos = new Vector3(-0.4f, 0.5981197f, 8.942495f);
			transform.position = startPos;
		}
		if (levels[6])
		{
			startPos = new Vector3(-0.5f, -0.38f, 7.5f);
			transform.position = startPos;
		}
		if (levels[7])
		{
			startPos = new Vector3(0.35f, -0.2f, 8f);
			transform.position = startPos;
		}
		if (levels[8])
		{
			startPos = new Vector3(0.7f, -2.5f, 7f);
			transform.position = startPos;
		}
		if (levels[9])
		{
			startPos = new Vector3(1f, -2.5f, 7f);
			transform.position = startPos;
		}
		timer += Time.deltaTime;
		if (timer >= 9&&!soundp[1]&&levels[0]&&!restarted) 
		{
			Play(1);
			soundp[1] = true;
			//return;
		}
		if (timer >= 12 && !soundp[2] && levels[0] && !restarted)
		{
			Play(2);
			soundp[2] = true;
			//return;
		}
		if (timer >= 17 && !soundp[3] && levels[0] && !restarted)
		{
			Play(3);
			soundp[3] = true;
			//return;
		}
		if (timer >= 20 && !soundp[4] && levels[0] && !restarted)
		{
			Play(4);
			soundp[4] = true;
			//return;
		}
		if (timer >= 26 && !soundp[5]&&PlayerPrefs.GetInt("dev")==1 && levels[0] && !restarted)
		{
			Play(5);
			soundp[5] = true;
			set.Documents();
			//return;
		}
		if (timer>= 42 && !soundp[6]&&levels[1] && !restarted)
		{
			Play(6);
			soundp[6] = true;
		}
		if (timer >= 80 && !soundp[7] && levels[1] && !restarted)
		{
			Play(7);
			soundp[7] = true;
		}
		if (timer >= 120 && !soundp[8] && levels[2] && !restarted)
		{
			Play(8);
			soundp[8] = true;
		}
		if (timer >= 160 && !soundp[9] && levels[3] && !restarted)
		{
			Play(9);
			soundp[9] = true;
		}
		if (timer >= 200 && !soundp[10] && levels[4] && !restarted)
		{
			Play(10);
			soundp[10] = true;
		}
		if (timer >= 250 && !soundp[11] && levels[5] && !restarted)
		{
			Play(11);
			soundp[11] = true;
		}
		if (timer >= 260 && !soundp[12] && levels[5] && !restarted)
		{
			Play(12);
			soundp[12] = true;
		}
		if (timer >= 300 && !soundp[13] && levels[6] && !restarted)
		{
			Play(13);
			soundp[13] = true;
		}
		if (timer >= 340 && !soundp[14] && levels[7] && !restarted)
		{
			Play(14);
			soundp[14] = true;
		}
		if (timer >= 380 && !soundp[15] && levels[8] && !restarted)
		{
			Play(15);
			soundp[15] = true;
		}
		if (timer >= timerc+3 && !soundp[17]&& soundp[16] && levels[9] && !restarted)
		{
			Play(17);
			soundp[17] = true;
			timerc = timerc + 3;
		}
		if (timer >= timerc+3 && !soundp[18] && soundp[17] && levels[9] && !restarted)
		{
			Play(18);
			soundp[18] = true;
		}

	}

	public void Play(int id)
	{
		vscript.audioSource = clip[id].clip;
		subtitle.text = clip[id].sub;
		vscript.audioSource.Play();
	}

	public void Stop()
	{
		subtitle.text = " ";
	}

}
