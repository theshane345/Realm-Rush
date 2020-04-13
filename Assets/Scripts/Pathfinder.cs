using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint Start1;
    [SerializeField] Waypoint End;
    // Start is called before the first frame update
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint>path = new List<Waypoint>();

    Vector2Int[] directions =
        {Vector2Int.up, Vector2Int.right,Vector2Int.down,Vector2Int.left};

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
           ClaculatePath();
        }
        return path;
    }

    private void ClaculatePath()
    {
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    void Start()
    {
        
    }

    private void CreatePath()
    {
        path.Add(End);
        // foreach () { }
        Waypoint previous = End.exploredFrom;
        while (previous != Start1) 
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(Start1);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(Start1);
        while (queue.Count > 0 && isRunning) 
        { 
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == End)
        {
            isRunning = false;
        }
        else
        {
            
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions) 
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(explorationCoordinates))
            {
                QueueNewNeighbours(explorationCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCoordinates)
    {
        Waypoint neighbour = grid[explorationCoordinates];

        if (neighbour.isExplored || queue.Contains(neighbour)) 
        {
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }
    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Over Lapping Block" + waypoint);
            }
            else 
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
