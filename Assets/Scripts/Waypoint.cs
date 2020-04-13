using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;

    public Waypoint exploredFrom;

    
    const int GridSize = 10;
    public int GetGridSize() 
    {
        return GridSize;
    }
    public Vector2Int GetGridPos() {
        return new Vector2Int(  
            Mathf.RoundToInt(transform.position.x / GridSize), 
            Mathf.RoundToInt(transform.position.z / GridSize));
    }
    private void Update()
    {
        //setTopColor(ExploredColor);
    }
    public void setTopColor(Color color) 
    {
        MeshRenderer topMeshRen = transform.Find("top").GetComponent<MeshRenderer>();
        topMeshRen.material.color = color;
    }
   
}
