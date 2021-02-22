using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformClass : MonoBehaviour
{
	public enum Type
	{
		Horizontal,
		Vertical,
		Floor,
		HighFloor
	}
	public enum WorkType
	{
		Loop,
		Triggered,
		Door,
		Elevator,
		Stop
	}
	public Type platformType;
	public WorkType workType;
	public float speed;
	public Vector3 start, end , direction;
	public GameObject trigger;
	public bool isDoor, first;

	

	private void Start()
	{
		start = transform.position;
		direction = end;
		if (first)
		{
			Trigger();
		}
	}

	public void Update()
	{

		if (workType == WorkType.Loop)
		{
			if (trigger.GetComponent<Trigger>().isTriggered)
			{
				return;
			}
			else
			{
				switch (platformType)
				{
					case Type.Vertical:
						transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * speed);
						if (Vector3.Distance(transform.position, end) < 0.05f)
							direction = start;
						else if (Vector3.Distance(transform.position, start) < 0.05f)
							direction = end;
						break;
					case Type.Horizontal:
						transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * speed);
						if (Vector3.Distance(transform.position, end) < 0.02f)
							direction = start;
						else if (Vector3.Distance(transform.position, start) < 0.02f)
							direction = end;
						break;
					case Type.Floor:
						break;
					case Type.HighFloor:
						break;
				}
			}

		}
		if (workType == WorkType.Triggered)
		{
			if (trigger.GetComponent<Trigger>().isTriggered)
			{
				if (workType == WorkType.Triggered)
				{
					switch (platformType)
					{
						case Type.Vertical:
							transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * speed);
							if (Vector3.Distance(transform.position, end) < 0.1f)
								direction = start;
							else if (Vector3.Distance(transform.position, start) < 0.1f)
								direction = end;
							break;
						case Type.Horizontal:
							transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * speed);
							if (Vector3.Distance(transform.position, end) < 0.1f)
								direction = start;
							else if (Vector3.Distance(transform.position, start) < 0.1f)
								direction = end;
							break;
						case Type.Floor:
							break;
						case Type.HighFloor:
							break;
					}
				}
			}
		}
		if (workType == WorkType.Elevator&& trigger.GetComponent<Trigger>().isTriggered)
		{
			switch (platformType)
			{
				case Type.Vertical:
					transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * speed);
					if (Vector3.Distance(transform.position, end) < 0.02f)
					{
						direction = start; //isDoor = false;
					}
					else if (Vector3.Distance(transform.position, start) < 0.02f)
					{
						direction = end; //isDoor = false;
					}
					if (Vector3.Distance(transform.position, direction) < 0.15f)
					{
						if (direction == start)
							direction = end;
						else
							direction = start;
						isDoor = false;
					}
					break;
				case Type.Horizontal:
					transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * speed);
					if (Vector3.Distance(transform.position, end) < 0.05f)
						direction = start;
					else if (Vector3.Distance(transform.position, start) < 0.05f)
						direction = end;
					break;
			}
		}
		if (isDoor|| trigger.GetComponent<Trigger>().door)
		{
			end = new Vector3(start.x, end.y, start.z);
			if (workType == WorkType.Door)
			{
				switch (platformType)
				{
					case Type.Vertical:
						transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * speed);
						print(Vector3.Distance(transform.position, direction));
						/*if (Vector3.Distance(transform.position, end) < 0.1f)
						{
							direction = start; //isDoor = false;
						}
						else if (Vector3.Distance(transform.position, start) < 0.1f)
						{
							direction = end; //isDoor = false;
						}*/
						if (Vector3.Distance(transform.position, direction) < 0.05f)
						{
							if (direction == start)
								direction = end;
							else
								direction = start;
							isDoor = false;
							trigger.GetComponent<Trigger>().door = false;
						}
						break;
					case Type.Horizontal:
						transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * speed);
						/*if (Vector3.Distance(transform.position, end) < 0.1f)
							direction = start;
						else if (Vector3.Distance(transform.position, start) < 0.1f)
							direction = end;*/
						if (Vector3.Distance(transform.position, direction) < 0.05f)
						{
							if (direction == start)
								direction = end;
							else
								direction = start;
							isDoor = false;
							trigger.GetComponent<Trigger>().door = false;
						}
						break;
				}
			}
		}
	}
	public void Trigger()
	{

		if (workType == WorkType.Door)
			isDoor = true;
	}
	public void ElevatorValue (int y, int x, int z)
	{
		print("aq");
		//if (workType == WorkType.Elevator)
		//{
			if (platformType == Type.Vertical)
			{
				end.y = y;
				print("baq");
			}
			else if (platformType == Type.Horizontal)
			{
				end.x = x;
				end.z = z;
				print("caq");
				direction = end;
			}
		//}
	}
}
