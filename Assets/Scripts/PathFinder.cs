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
	List<Waypoint> path = new List<Waypoint>(); // constructed a new list to prevent errors and for it to show in the editor. (Game didnt work with out it)
	Vector2Int[] directions = {
		 Vector2Int.up,
		 Vector2Int.right,
		 Vector2Int.down,
		 Vector2Int.left

	};

	public List<Waypoint> GetPath()
	{
		LoadBlocks();
		ColorStartAndEnd();
		BreadthFirstSearch();
		CreatePath();
		return path;
	}

	private void CreatePath()
	{
		path.Add(endWaypoint);

		Waypoint previous = endWaypoint.exploredFrom;
		while (previous != startWaypoint)
		{
			path.Add(previous);
			previous = previous.exploredFrom;
		}

		path.Add(startWaypoint);
		path.Reverse();		
	}

	private void BreadthFirstSearch()
	{
		queue.Enqueue(startWaypoint);

		while(queue.Count > 0 && isRunning)
		{
			searchCenter = queue.Dequeue();
			
			HaltIfEndFound();
			ExploreNeighbours();
			searchCenter.isExplored = true;

		}
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
			if (grid.ContainsKey(neighbourCoordinates))
			{
				QueueNewNeighbours(neighbourCoordinates);
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
		// todo consider moving out
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
