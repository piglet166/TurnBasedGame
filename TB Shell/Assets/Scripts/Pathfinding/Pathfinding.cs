using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Movement move;
    List<Tile> tilesInRange = new List<Tile>();
    List<CharacterType> enemiesInRange = new List<CharacterType>();
    Stack<Tile> path = new Stack<Tile>();
    GameObject[] tiles;

    private void Awake()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    private void Update()
    {
        //FindPath(StartPosition, TargetPosition);
    }

    public void FindPath(GameObject a_StartPos, GameObject a_TargetPos)
    {
        Tile StartTile = move.GetTarget(a_StartPos);
        Tile TargetTile = move.GetTarget(a_TargetPos);
        //Get target and starting tiles instead of nodes

        //List<Node> OpenList = new List<Node>();
        //HashSet<Node> ClosedList = new HashSet<Node>();
        List<Tile> OpenList = new List<Tile>();
        HashSet<Tile> ClosedList = new HashSet<Tile>();

        OpenList.Add(StartTile);

        while(OpenList.Count > 0)
        {
            Tile CurrentNode = OpenList[0];

			for (int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].ihCost < CurrentNode.ihCost)//If the f cost of that object is less than or equal to the f cost of the current node
                {
                    CurrentNode = OpenList[i];
                }
            }

			OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            Vector3 CurrentVector = CurrentNode.transform.position;
            Vector3 TargetVector = TargetTile.transform.position;

            //trash code
            TargetVector.x--;

            if (CurrentVector == TargetVector)
            {
                GetFinalPath(StartTile, CurrentNode);
            }

            CurrentNode.FindSurroundingTiles();

            foreach (Tile NeighborNode in CurrentNode.surrondingTiles)
            {
                if (ClosedList.Contains(NeighborNode))
                {
                    continue;
                }

				int MoveCost = CurrentNode.igCost + GetManhattenDistance(CurrentNode, NeighborNode);

                if (MoveCost < NeighborNode.igCost || !OpenList.Contains(NeighborNode))
                {
                    Debug.Log("Parents found");

                    NeighborNode.igCost = MoveCost;
                    NeighborNode.ihCost = GetManhattenDistance(NeighborNode, TargetTile);
                    NeighborNode.parent = CurrentNode;

                    if(!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }

        }
    }

    void GetFinalPath(Tile a_StartingNode, Tile a_EndNode)
    {
        Stack<Tile> FinalPath = new Stack<Tile>();
        Tile CurrentNode = a_EndNode;

        while(CurrentNode != a_StartingNode)
        {
            FinalPath.Push(CurrentNode);
            CurrentNode = CurrentNode.parent;
        }
        Debug.Log("Decided:");
        move.SetPath(FinalPath);
    }

    int GetManhattenDistance(Tile a_nodeA, Tile a_nodeB)
    {
        Vector3 pos_NodeA = a_nodeA.transform.position;
        Vector3 pos_NodeB = a_nodeB.transform.position;

        int ix = (int)Mathf.Abs(pos_NodeA.x - pos_NodeB.x);
        int iy = (int)Mathf.Abs(pos_NodeA.y - pos_NodeB.y);

        return ix + iy;
    }
}