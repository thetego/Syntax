using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Console : MonoBehaviour
{
	public TMP_InputField commandEntry;
	public TMP_Text commandHistory;
	public string[] words;
	public GameObject cubeParent, doorParent, elevatorParent;
	public int hak, first;
	public Move mv;
	public AudioSource src;
	public JENNA jn;




	private void Update()
	{
		if (SceneManager.GetActiveScene().buildIndex == 5)
		{
			hak = 3;
			first = 3;
		}
		doorParent = GameObject.Find("Doors");
		cubeParent = GameObject.Find("Cubes");
		elevatorParent = GameObject.Find("Elevators");
		jn = GameObject.Find("Jenna").GetComponent<JENNA>();
		mv = GameObject.Find("Player").GetComponent<Move>();
		if (Input.GetKeyDown(KeyCode.Return))
		{
			words = commandEntry.text.Split('_');
			if (words[0] == "god")
			{
				src.Play();

				hak = 99999999;
			}
			if (words[0] == "restart")
			{
				src.Play();
				Time.timeScale = 1;
				jn.restarted = true;
				//jn.timer = 
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

				hak = first;
			}
			if (hak > 0)
			{
				CommandEnter();
			}



		}
		if (commandEntry.isFocused)
		{
			mv.enabled = false;
		}
		else
		{
			mv.enabled = true;
		}
	}

	public void CommandEnter()
	{
		words = commandEntry.text.Split('_');

		switch (words[0])
		{
			case "door":
				if (words[2] == "true")
				{
					doorParent.transform.GetChild(int.Parse(words[1])).transform.GetComponent<PlatformClass>().direction = doorParent.transform.GetChild(int.Parse(words[1])).GetComponent<PlatformClass>().end;
					doorParent.transform.GetChild(int.Parse(words[1])).GetComponent<PlatformClass>().Trigger();
					src.Play();
					hak -= 1;
				}
				else if (words[2] == "false")
				{
					doorParent.transform.GetChild(int.Parse(words[1])).GetComponent<PlatformClass>().direction = doorParent.transform.GetChild(int.Parse(words[1])).GetComponent<PlatformClass>().start;
					doorParent.transform.GetChild(int.Parse(words[1])).GetComponent<PlatformClass>().Trigger();
					src.Play();
					hak -= 1;
				}
				break;
			case "box":
				if (words[2] == "position")
				{
					cubeParent.transform.GetChild(int.Parse(words[1])).transform.position = new Vector3(int.Parse(words[3]), cubeParent.transform.GetChild(int.Parse(words[1])).transform.position.y, int.Parse(words[4]));
					src.Play();
					hak -= 1;
				}
				if (words[2] == "scale")
				{
					print(words[1] + "scale");
				}
				break;
			case "jump":
				if (words[1] == "max")
				{
					print (int.Parse(words[2])+" value");
				}
				break;
			case "elevator":
				if (words[2] == "level")
				{
					if (elevatorParent.transform.GetChild(int.Parse(words[1])).transform.GetComponent<PlatformClass>().platformType == PlatformClass.Type.Vertical)
					{
						elevatorParent.transform.GetChild(int.Parse(words[1])).transform.GetComponent<PlatformClass>().ElevatorValue(int.Parse(words[3]), 0, 0);
						src.Play();
						hak -= 1;
					}
					else if (elevatorParent.transform.GetChild(int.Parse(words[1])).transform.GetComponent<PlatformClass>().platformType == PlatformClass.Type.Horizontal)
					{
						elevatorParent.transform.GetChild(int.Parse(words[1])).transform.GetComponent<PlatformClass>().ElevatorValue(0, int.Parse(words[3]), int.Parse(words[4]));
						src.Play();
						hak -= 1;
					}
				}
				break;

		}
		commandHistory.text += "\n" + commandEntry.text;
		commandEntry.text = "";
		commandEntry.ActivateInputField();
		
	}

}
