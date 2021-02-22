using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

	public float cell;
	public float moveSpeed;
	public float timer;
	public Animator anim;

	Transform Cube;

	Vector3 currentPos;
	Vector3 ofsetHorizontalPositive;
	Vector3 ofsetHorizontalNegative;
	Vector3 ofsetVerticalPositive;
	Vector3 ofsetVerticalNegative;

	Vector3 currentDirection;


	float time;
	bool isClick;
	bool snatch;

	bool cubeOnHere;
	int which = 0;
	bool isDir = true;
	void Start()
	{
		ofsetHorizontalPositive = new Vector3(cell, 0, 0);
		ofsetHorizontalNegative = new Vector3(-cell, 0, 0);
		ofsetVerticalPositive = new Vector3(0, 0, cell);
		ofsetVerticalNegative = new Vector3(0, 0, -cell);

		currentPos = transform.position;

	}

	void Update()
	{
		Movement();
		MoveDirection();
		Snatch();
	}
	void Movement()
	{
		RaycastHit hitHorizontalPositive;
		RaycastHit hitVerticalNegative;
		RaycastHit hitVerticalPositive;
		RaycastHit hitHorizontalNegative;

		Vector3 chechPositionLeft = transform.position;
		Vector3 chechPositionRight = transform.position;
		Vector3 chechPositionForward = transform.position;
		Vector3 chechPositionBack = transform.position;
		bool checkDoubleSide = false;
		bool checkDoubleFront = false;
		if (cubeOnHere)
		{
			if (currentDirection == Vector3.left)
			{
				chechPositionLeft += Vector3.left * cell;
				checkDoubleSide = true;
			}
			if (currentDirection == Vector3.right)
			{
				chechPositionRight += Vector3.right * cell;
				checkDoubleSide = true;
			}
			if (currentDirection == Vector3.forward)
			{
				chechPositionForward += Vector3.forward * cell;
				checkDoubleFront = true;
			}
			if (currentDirection == Vector3.back)
			{
				chechPositionBack += Vector3.back * cell;
				checkDoubleFront = true;
			}
		}

		if (Input.GetKey(KeyCode.D)
			&& !isClick
			&& !Physics.Raycast(chechPositionRight, Vector3.right, cell)
			&& Physics.Raycast(chechPositionRight + ofsetHorizontalPositive, Vector3.down, out hitHorizontalPositive, Mathf.Infinity))
		{
			if (checkDoubleFront == false
		   ||
			(checkDoubleFront == true
			  && !Physics.Raycast(transform.position + currentDirection * cell, Vector3.right, cell)
			  && Physics.Raycast(transform.position + currentDirection * cell + ofsetHorizontalPositive, Vector3.down, out hitHorizontalPositive, Mathf.Infinity)))
			{
				currentPos = hitHorizontalPositive.collider.transform.position; //transform.position + Vector3.right * cell;
				isClick = true;
			}
		}
		else if (Input.GetKey(KeyCode.A)
			&& !isClick
			 && !Physics.Raycast(chechPositionLeft, Vector3.left, cell)   //bişi var mi
			 && Physics.Raycast(chechPositionLeft + ofsetHorizontalNegative, Vector3.down, out hitHorizontalNegative, Mathf.Infinity))//yer var mi
		{
			if (checkDoubleFront == false
		   ||
			(checkDoubleFront == true
			  && !Physics.Raycast(transform.position + currentDirection * cell, Vector3.left, cell)
			  && Physics.Raycast(transform.position + currentDirection * cell + ofsetHorizontalNegative, Vector3.down, out hitHorizontalNegative, Mathf.Infinity)))
			{
				currentPos = hitHorizontalNegative.collider.transform.position; //transform.position + Vector3.left *cell;
				isClick = true;
			}
		}
		else if (Input.GetKey(KeyCode.W) &&
			!isClick &&
			(!Physics.Raycast(chechPositionForward, Vector3.forward, cell)) &&
			Physics.Raycast(chechPositionForward + ofsetVerticalPositive, Vector3.down, out hitVerticalPositive, Mathf.Infinity))
		{

			if (checkDoubleSide == false
			||
			 (checkDoubleSide == true
			   && !Physics.Raycast(transform.position + currentDirection * cell, Vector3.forward, cell)
			   && Physics.Raycast(transform.position + currentDirection * cell + ofsetVerticalPositive, Vector3.down, out hitVerticalPositive, Mathf.Infinity)))
			{
				currentPos = hitVerticalPositive.collider.transform.position; //transform.position + Vector3.forward * cell;
				isClick = true;
			}
		}
		else if (Input.GetKey(KeyCode.S) &&
			!isClick &&
			 (!Physics.Raycast(chechPositionBack, -Vector3.forward, cell)) &&
			Physics.Raycast(chechPositionBack + ofsetVerticalNegative, Vector3.down, out hitVerticalNegative, Mathf.Infinity))
		{

			if (checkDoubleSide == false
			||
			 (checkDoubleSide == true
			   && !Physics.Raycast(transform.position + currentDirection * cell, -Vector3.forward, cell)
			   && Physics.Raycast(transform.position + currentDirection * cell + ofsetVerticalNegative, Vector3.down, out hitVerticalNegative, Mathf.Infinity)))
			{
				currentPos = hitVerticalNegative.collider.transform.position;  //transform.position - Vector3.forward * cell;
				isClick = true;
			}
		}
		//print((transform.position - currentPos).magnitude);

		anim.SetFloat("speed", (transform.position - currentPos).magnitude);

		//if((transform.position - currentPos).magnitude > 1.1f)
		//{
		//    anim.Play("Running", -1, 1.0f);
		//}
		//else if((transform.position - currentPos).magnitude < 1.1f)
		//{
		//   anim.Play("Idle", -1, 0.0f);
		//}



		//a.SetFloat("speed", (transform.position - currentPos).magnitude);        //anim
		transform.position = Vector3.Lerp(transform.position, currentPos + new Vector3(0, 1, 0), Time.deltaTime * moveSpeed);

		if (isClick)
		{
			time += Time.deltaTime;
			if (time >= timer)
			{
				isClick = false;
				time = 0f;
			}
		}
	}
	bool mouseClik;
	void Snatch()
	{
		RaycastHit ray;
		/*if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward, out ray, 4))
		{
			anim.Play("Pushing", -1, 0.0f);
			if (ray.collider.gameObject.layer == 8)
			{
				which++;
				if (which >= 2)
				{
					which = 0;
				}
			}
		}*/

		if (which >= 1)//Snatch
		{
			cubeOnHere = true;

			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.forward, out hit, 4))
			{
				if (hit.collider.gameObject.layer == 8)
				{
					hit.transform.parent = this.transform;
					Cube = hit.collider.gameObject.transform;
					isDir = false;
				}
			}
		}
		else if (which < 1)//Refresh
		{
			if (Cube != null)
				Cube.transform.parent = null;
			isDir = true;
			cubeOnHere = false;
		}
	}
	void MoveDirection()
	{
		//Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * 100);
		if (isDir)
		{
			if (Input.GetKey(KeyCode.W))
			{
				transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
				currentDirection = Vector3.forward;
				//anim.Play("Running", -1, 0.0f);
			}
			else if (Input.GetKey(KeyCode.D))
			{
				currentDirection = Vector3.right;
				transform.rotation = Quaternion.Euler(transform.rotation.x, 90, transform.rotation.z);
				//anim.Play("Running", -1, 0.0f);
			}
			else if (Input.GetKey(KeyCode.A))
			{
				transform.rotation = Quaternion.Euler(transform.rotation.x, -90, transform.rotation.z);
				//anim.Play("Running", -1, 0.0f);
				currentDirection = Vector3.left;
			}
			else if (Input.GetKey(KeyCode.S))
			{
				transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
				//anim.Play("Running", -1, 0.0f);
				currentDirection = Vector3.back;
			}



		}



	}
	private void OnDrawGizmos()
	{
		Debug.DrawRay(transform.position + ofsetHorizontalPositive, Vector3.down, Color.yellow);
		Debug.DrawRay(transform.position + ofsetHorizontalNegative, Vector3.down, Color.red);
		Debug.DrawRay(transform.position + ofsetVerticalPositive, Vector3.down, Color.green);
		Debug.DrawRay(transform.position + ofsetVerticalNegative, Vector3.down, Color.cyan);

		Debug.DrawRay(transform.position, Vector3.right * cell, Color.yellow);
		Debug.DrawRay(transform.position, Vector3.right * -cell, Color.red);
		Debug.DrawRay(transform.position, Vector3.forward * cell, Color.green);
		Debug.DrawRay(transform.position, Vector3.forward * -cell, Color.cyan);

	}
}
