using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 WorldPosition;

    public int gCost, hCost;

    public Node(bool _walkable, Vector3 _worldposition)
    {
        walkable = _walkable;
        WorldPosition = _worldposition;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
