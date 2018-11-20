using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
	[SerializeField] float movementSpeed = 2f;
	

		void Start () 
	{
		PathFinder pathFinder = FindObjectOfType<PathFinder>();
		List<Waypoint> path = pathFinder.GetPath();
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
		print("Ending patrol");
	}
	
	// Update is called once per frame	
}
