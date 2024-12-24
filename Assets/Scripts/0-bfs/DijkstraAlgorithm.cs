using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra 
{
    public static void FindPath<NodeType> (IGraph<NodeType> graph, NodeType startNode, NodeType endNode, List<NodeType> outputPath) 
    {
        Dictionary<NodeType, NodeType> nextTileForEachTile = new Dictionary<NodeType, NodeType>(); 
        Dictionary<NodeType, int> weightOfPathFromThisTile = new Dictionary<NodeType, int>(); 

        PriorityQueue<NodeType> theNextVisited = new PriorityQueue<NodeType>(); 
        theNextVisited.Enqueue(endNode, 0);
        weightOfPathFromThisTile[endNode] = 0;

        while (theNextVisited.Count > 0) {
            NodeType searchFocus = theNextVisited.Dequeue();
            if (searchFocus.Equals(startNode)) {
                break;
            }

            foreach (var neighbor in graph.Neighbors(searchFocus)) {
                int newWeight = weightOfPathFromThisTile[searchFocus] + graph.GetWeight(neighbor);
                if (weightOfPathFromThisTile.ContainsKey(neighbor) == false || newWeight < weightOfPathFromThisTile[neighbor]) {
                    weightOfPathFromThisTile[neighbor] = newWeight;
                    theNextVisited.Enqueue(neighbor, newWeight);
                    nextTileForEachTile[neighbor] = searchFocus;
                }
            }
        }

        if (nextTileForEachTile.ContainsKey(startNode) == false) {
            Debug.Log("the current position cannot reach the target position");
            return;
        }

        NodeType nodePath = startNode;
        while (!(nodePath.Equals(endNode))) {
            nodePath = nextTileForEachTile[nodePath];
            outputPath.Add(nodePath);
        }
    }

    public static List<NodeType> GetPath<NodeType>(IGraph<NodeType> graph, NodeType startNode, NodeType endNode) {
        List<NodeType> path = new List<NodeType>();
        FindPath(graph, startNode, endNode, path);
        return path;
    }
}