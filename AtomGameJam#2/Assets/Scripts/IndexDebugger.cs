using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IndexDebugger : MonoBehaviour
{
	public TMP_Text indicator;
	public bool isDev;
	public int index;
	public bool isFloor;

	private void Awake()
	{
		indicator.gameObject.SetActive(false);
		indicator.text ="Index: "+ index.ToString();
		isDev = false;

	}
	void Update()
	{
		if (PlayerPrefs.GetInt("dev") == 1)
		{
			isDev = true;
		}
		else if (PlayerPrefs.GetInt("dev") == 0)
		{
			isDev = false;
		}
	}

	private void OnMouseOver()
	{
		if (isDev)
		{
			if (!isFloor)
			{
				indicator.text = "Index: " + index.ToString();
				indicator.gameObject.SetActive(true);

				indicator.gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x + 50, Input.mousePosition.y - 50, 0);
			}
			else
			{
				indicator.text = "X (" + Mathf.FloorToInt(transform.position.x) + ")" + " Z (" + Mathf.FloorToInt(transform.position.z) + ")";
				indicator.gameObject.SetActive(true);

				indicator.gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x + 50, Input.mousePosition.y +75, 0);
			}
		}

	}
	private void OnMouseExit()
	{
		indicator.gameObject.SetActive(false);
	}
}
