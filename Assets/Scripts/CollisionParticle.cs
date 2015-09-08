using UnityEngine;
using System.Collections;

public class CollisionParticle : MonoBehaviour
{

	public ParticleSystem particleEffect;

	void OnControllerColliderHit(ControllerColliderHit hit) 
	{
		if(hit.gameObject.tag == "Wall")
		{
			Debug.Log("Bump !");
			Instantiate(particleEffect,transform.position,Quaternion.identity);
		}
	}
}