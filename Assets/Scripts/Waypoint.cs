using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
 {
	 [SerializeField] Color exploredColor;
	 public bool isExplored = false; // ok public as is a data class
	 public Waypoint exploredFrom;
	 Vector2Int gridPos;
	const int gridSize = 10;

	// Use this for initialization

	void Update()
	{
	ApplyTopColor();
		
	}

	void ApplyTopColor()
	{		
		if (isExplored == true)
		{
			SetTopColor(Color.blue);
		}

		//todo add colors for more options later

	}

	public int GetGridSize()
	{
		return gridSize;
	}

	public Vector2Int GetGridPos()
	{	
		
		return new Vector2Int
		(
			Mathf.RoundToInt(transform.position.x/gridSize),
        	Mathf.RoundToInt(transform.position.z/gridSize)
		);		
	}	

	public void SetTopColor(Color color)
	{
		MeshRenderer topMeshrenderer = transform.Find("top").GetComponent<MeshRenderer>();
		topMeshrenderer.material.color = color;
	}
}
