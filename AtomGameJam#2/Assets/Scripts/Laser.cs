using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public Vector3 ofset, linepos, linestart, firstpos;
    public LineRenderer partical;
    bool gameOver;
    float timer;
	public float range;
	public GameObject follower;
	public Animator anim;

	public enum Type
	{
		X,
		Z
	}
	public Type ts;

	void Awake()
	{
		firstpos = partical.GetPosition(1);

	}

    void Update()
    {
		linestart = follower.transform.position;
		partical.SetPosition(0, linestart);
		//partical.SetPosition(1, new Vector3 (linepos.x,linepos.y,linestart.z));
		RaycastHit hit;

        if (Physics.Raycast(transform.position + ofset, -transform.forward, out hit, range))
        {
            print("hit distance: "+ hit.distance);
			linepos = partical.GetPosition(1);
			if (ts == Type.X)
			{
				partical.SetPosition(1, new Vector3(hit.point.x, hit.point.y, hit.point.z));
			}
			if (ts == Type.Z)
			{
				partical.SetPosition(1, new Vector3(hit.point.x, hit.point.y, hit.point.z));
			}
            if (hit.collider.tag == "Player")
            {
                gameOver = true;
				print("hişt");
            }
        }
		else
		{
			if (ts==Type.X)
				partical.SetPosition(1, new Vector3(firstpos.x,firstpos.y,follower.transform.position.z));
			if(ts==Type.Z)
				partical.SetPosition(1, new Vector3(firstpos.x, firstpos.y, firstpos.z));
		}
        if (gameOver)
        {
            timer += Time.deltaTime;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			print("AQ");
            if (timer >= 5f)
            {
				print("AQS");
				
            }
        }

    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + ofset, -transform.forward * range, Color.yellow);
    }
}
