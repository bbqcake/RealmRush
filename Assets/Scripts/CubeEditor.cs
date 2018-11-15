using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase] // makes it harder to select the text but I didnt like it
[RequireComponent(typeof(Waypoint))]
public class CubeEditor: MonoBehaviour
{  

  
    
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        snapToGrid();
        updateLabel();
          
    }

    private void snapToGrid()
    {
        int gridSize = waypoint.GetGridSize();        
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);      
    }

    private void updateLabel()
    {                
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x + " " + waypoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = "Cube " + labelText;
    }

}