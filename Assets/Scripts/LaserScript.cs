using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	LineRenderer line;
	public ParticleSystem particleEffect;
	// Use this for initialization
	void Start () 
	{
		line = gameObject.GetComponent<LineRenderer> ();
		//particleEffect = gameObject.GetComponent<ParticleSystem> ();
		line.enabled = false;

		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
		}
	}
	IEnumerator FireLaser()
	{
		line.enabled = true;
		while (Input.GetButton("Fire1")) 
		{
			Ray ray = new Ray(transform.position,transform.forward);
			RaycastHit hit;

			line.SetPosition(0,ray.origin);

			if(Physics.Raycast(ray,out hit,100))
			{
				line.SetPosition(1,hit.point);
				if(hit.collider)
				{
					Debug.Log("Laser Colliding!");
					Instantiate(particleEffect,hit.point,Quaternion.identity);
				}

			}
		    else
			   line.SetPosition(1,ray.GetPoint(100));

			yield return null;
		}
		line.enabled = false;
	}
}
