using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed, rotationSpeed;
	public CharacterController car;

	private void Update()
	{
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		Vector3 move = new Vector3(hor, 0, ver)*Time.deltaTime*speed;

		car.Move(move);
		Rotate();

	}
	void Rotate()
	{
		if (car.velocity.magnitude < 0.2f) { return; }
		Vector3 movedir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movedir),Time.deltaTime*rotationSpeed);
	}
}
