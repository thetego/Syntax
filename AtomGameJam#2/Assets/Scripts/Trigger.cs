using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
	public bool isTriggered, door;



	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Cube")
		{
			isTriggered = true;
			door = true;
		}
	}
	public void OnTriggerExit(Collider other)
	{
		if (other.tag == "Cube")
		{
			StartCoroutine(Wait());
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1f);
		isTriggered = false;
	}
}
