using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM : MonoBehaviour
{
	bool trig;
	GameObject player;
	public Console asd;
	void Awake()
	{
		player = GameObject.Find("Player");
		asd = GameObject.Find("Jenna").transform.GetChild(0).transform.GetChild(0).GetComponent<Console>();
	}

	void Update()
	{
		if (trig)
		{
			player.transform.position = new Vector3(transform.position.x,player.transform.position.y,transform.position.z);
		}
		if (!asd.commandEntry.isFocused&&trig&&Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
		{
			trig = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Player")
		{
			trig = true;
		}
	}


}
