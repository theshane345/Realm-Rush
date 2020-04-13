using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public bool isPlaceable = true;
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

    void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0))
            {
            if (isPlaceable == true)
                {
                    print(gameObject.name + " clicked and placed");
                }
            else
                {
                    print("cannot place here");
                }
        }
       
    }
}
