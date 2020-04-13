using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class EditorSnap : MonoBehaviour
{
   
    Vector3 snapPos;
    
    Waypoint waypoint; 

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        snapToGrid();
        UpdateLabel();
    }

    private void snapToGrid()
    {
        int GridSize = waypoint.GetGridSize();
        
        transform.position = new Vector3(
            waypoint.GetGridPos().x * GridSize, 0f, 
            waypoint.GetGridPos().y * GridSize) ;
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int GridSize = waypoint.GetGridSize();
        string text =
            waypoint.GetGridPos().x  +
            "," 
            + waypoint.GetGridPos().y;

        textMesh.text = text;
        gameObject.name = text;
    }
}
