using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour 
{
	[SerializeField] float movementSpeed = 2f;
	[SerializeField] ParticleSystem goalParticle;
	

		void Start () 
	{
		PathFinder pathFinder = FindObjectOfType<PathFinder>();
		var path = pathFinder.GetPath();
		StartCoroutine(FollowPath(path));

	}

 	IEnumerator FollowPath(List<Waypoint> path) // can run at the same time as other things
	{
		print ("Starting patrol");
		foreach (Waypoint waypoint in path)
		{			
			transform.position = waypoint.transform.position;			
			yield return new WaitForSeconds(movementSpeed);
		}
		SelfDestruct();
		
	}
	
	private void SelfDestruct()
	{			
		var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
		vfx.Play();

		float destroyDelay = vfx.main.duration;		
		Destroy(gameObject);		
	}
}
