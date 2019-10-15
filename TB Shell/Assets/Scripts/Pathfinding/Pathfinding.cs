using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Grid GridReference;
    public Transform StartPosition;
    public Transform TargetPosition;
    public Movement move;
    List<Tile> tilesInRange = new List<Tile>();
    List<CharacterType> enemiesInRange = new List<CharacterType>();
    Stack<Tile> path = new Stack<Tile>();
    GameObject[] tiles;

    private void Awake()
    {
        GridReference = GetComponent<Grid>();
        tiles = GameObject.FindGameObjectsWithTag("Tiles");
    }

    private void Update()
    {
        FindPath(StartPosition.position, TargetPosition.position);
    }

    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos)
    {
        Node StartNode = GridReference.NodeFromWorldPoint(a_StartPos);
        Node TargetNode = GridReference.NodeFromWorldPoint(a_TargetPos);
        //Get target and starting tiles instead of nodes

        //List<Node> OpenList = new List<Node>();
        //HashSet<Node> ClosedList = new HashSet<Node>();
        List<Tile> OpenList = new List<Tile>();
        HashSet<Tile> ClosedList = new HashSet<Tile>();

        OpenList.Add(StartNode);

        while(OpenList.Count > 0)
        {
            Node CurrentNode = OpenList[0];

			for (int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].ihCost < CurrentNode.ihCost)//If the f cost of that object is less than or equal to the f cost of the current node
                {
                    CurrentNode = OpenList[i];
                }
            }

			OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
            }

            foreach (Node NeighborNode in GridReference.GetNeighboringNodes(CurrentNode))
            {
                if (!NeighborNode.bIsWall || ClosedList.Contains(NeighborNode))
                {
                    continue;
                }

				int MoveCost = CurrentNode.igCost + GetManhattenDistance(CurrentNode, NeighborNode);

                if (MoveCost < NeighborNode.igCost || !OpenList.Contains(NeighborNode))
                {
                    NeighborNode.igCost = MoveCost;
                    NeighborNode.ihCost = GetManhattenDistance(NeighborNode, TargetNode);
                    NeighborNode.ParentNode = CurrentNode;

                    if(!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }

        }
    }

    void GetFinalPath(Node a_StartingNode, Node a_EndNode)
    {
        //List<Node> FinalPath = new List<Node>();
        List<Tile> FinalPath = new List<Tile>();
        //Node CurrentNode = a_EndNode;
        Tile CurrentNode = a_EndNode;

        while(CurrentNode != a_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.ParentNode;
        }

        FinalPath.Reverse();

        GridReference.FinalPath = FinalPath;
    }

    int GetManhattenDistance(Node a_nodeA, Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.iGridX - a_nodeB.iGridX);
        int iy = Mathf.Abs(a_nodeA.iGridY - a_nodeB.iGridY);

        return ix + iy;
    }
}