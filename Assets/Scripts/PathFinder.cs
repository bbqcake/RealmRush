using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
 {
	
	[SerializeField] Waypoint startWaypoint, endWaypoint;
	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Waypoint searchCenter; // current search center
	Vector2Int[] directions = {
		 Vector2Int.up,
		 Vector2Int.right,
		 Vector2Int.down,
		 Vector2Int.left

	};

	// Use this for initialization
	void Start () 
	{
		LoadBlocks();
		ColorStartAndEnd();
		PathFind();
		//ExploreNeighbours();
	}

	private void PathFind()
	{
		queue.Enqueue(startWaypoint);

		while(queue.Count > 0 && isRunning)
		{
			searchCenter = queue.Dequeue();
			
			HaltIfEndFound();
			ExploreNeighbours();
			searchCenter.isExplored = true;

		}
		// todo work out path
		print("Pahtfinding finished?");

	}

	private void HaltIfEndFound()
	{
		if (searchCenter == endWaypoint)
		{				
			isRunning = false;
		}
		
	}

	private void ExploreNeighbours() 
	{
		if (!isRunning) { return; } // protection
		foreach (Vector2Int directions in directions)
		{
			Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + directions;
			try
			{
				QueueNewNeighbours(neighbourCoordinates);
			}
			catch
			{
				// do nothing
			}
			
		}
	}

	private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
	{
		Waypoint neighbour = grid[neighbourCoordinates];
		if (neighbour.isExplored || queue.Contains(neighbour))
		{
			// do nothing
		}
		else
		{			
			queue.Enqueue(neighbour);
			neighbour.exploredFrom = searchCenter;
			
		}
		
	}

	private void ColorStartAndEnd()
	{
		startWaypoint.SetTopColor(Color.green);
		endWaypoint.SetTopColor(Color.black);
	}

	private void LoadBlocks()
	{
		var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint waypoint in waypoints)
		{
			Vector2Int gridPos = waypoint.GetGridPos();			
			if (grid.ContainsKey(gridPos))
			{
				Debug.LogWarning("Skipping overlapping block " + waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);				
			}			
		}		
	}	
}
