using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Grid grid;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openset = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openset.Add(startNode);

        while (openset.Count > 0)
        {
            Node currentNode = openset[0];
            for (int i = 1; i < openset.Count; i++)
            {
                if (openset[i].fCost < currentNode.fCost || openset[i].fCost == currentNode.fCost && openset[i].hCost < currentNode.hCost)
                {
                    currentNode = openset[i];
                }
            }
            openset.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                return;
            }

        }
    }






}
