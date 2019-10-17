using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    List<Tile> tilesInRange = new List<Tile>();
    List<CharacterType> enemiesInRange = new List<CharacterType>();
    Stack<Tile> path = new Stack<Tile>();
    GameObject[] tiles;

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();
    Tile currentTile;
    public Tile actualTarget;

    public bool moving;
    public int moveLimit;
    public int attackLimit;
    int moveSpeed = 2;
    float piecePos = 0;

    protected int moved;
    protected bool attacked;

    protected void Init() {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        piecePos = GetComponent<Collider>().bounds.extents.y;
    }

    public void GetCurrentTile() {
        currentTile = GetTarget(gameObject);
        currentTile.current = true;
    }

    public Tile GetTarget(GameObject target) {
        RaycastHit hit;
        Tile tile = null;

        Debug.DrawRay(target.transform.position, -Vector3.up, Color.green);

        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1)) {
            tile = hit.collider.GetComponent<Tile>();
        }
        return tile;
    }

    public void CreateSurrTileList(Tile target) {
        foreach (GameObject tile in tiles) {
            Tile t = tile.GetComponent<Tile>();
            t.FindSurroundingTiles(target);
        }
    }

    public void CreateEnemyList() {
        foreach (GameObject tile in tiles) {
            Tile e = tile.GetComponent<Tile>();
            e.FindEnemy();
        }
    }

    public void BreadthFirstSeach() {
        CreateSurrTileList(null);
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();
        process.Enqueue(currentTile);
        currentTile.visited = true;

        while (process.Count > 0) {
            Tile t = process.Dequeue();

            tilesInRange.Add(t);
            t.selectable = true;

            if (t.tilesMoved < moveLimit) {
                foreach (Tile tile in t.surrondingTiles) {
                    if (!tile.visited) {
                        tile.parent = t;
                        tile.visited = true;
                        tile.tilesMoved = 1 + t.tilesMoved;
                        process.Enqueue(tile);
                    }
                }
            }
        }
    }

    public void EnemyBFS() {
        CreateEnemyList();
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();
        process.Enqueue(currentTile);
        currentTile.visited = true;

        while (process.Count > 0) {
            Tile t = process.Dequeue();

            tilesInRange.Add(t);
            t.selectable = true;



            if (t.tilesMoved < attackLimit) {
                foreach (Tile tile in t.surrondingTiles) {
                    if (!tile.visited) {
                        tile.parent = t;
                        tile.visited = true;
                        tile.tilesMoved = 1 + t.tilesMoved;
                        process.Enqueue(tile);
                    }
                }
            }
        }
    }

    protected void Astar(Tile target) {
        CreateSurrTileList(target);
        GetCurrentTile();

        List<Tile> openList = new List<Tile>();
        List<Tile> closedList = new List<Tile>();

        openList.Add(currentTile);
        //current.parent = null ??? <<<<<<<<<<<<<<<<<<<

        currentTile.hCost = Vector3.Distance(currentTile.transform.position,
                                                target.transform.position);
        currentTile.fCost = currentTile.hCost;

        //What if you can't reach the player or there's no path? <<<<<<<<<<<<<<<<,,
        while (openList.Count > 0) {
            Tile t = FindLowestFcost(openList);

            closedList.Add(t);

            if(t == target) {
                actualTarget = FindEndTile(t);
                MoveToTarget(actualTarget);
                return;
            }

            foreach(Tile tile in t.surrondingTiles) {
                if (closedList.Contains(tile)) {
                    //do nothing

                } else if (openList.Contains(tile)) {
                    float newG = t.gCost + Vector3.Distance(tile.transform.position, t.transform.position);

                    if(newG < tile.gCost) {
                        tile.parent = t;

                        tile.gCost = newG;
                        tile.fCost = tile.gCost + tile.hCost;
                    }
                } else {
                    tile.parent = t;

                    tile.gCost = t.gCost + Vector3.Distance(tile.transform.position, t.transform.position);
                    tile.hCost = Vector3.Distance(tile.transform.position, target.transform.position);
                    tile.fCost = tile.gCost + tile.hCost;

                    openList.Add(tile);
                }
            }
        }
        Debug.Log("Path not found");
    }

    public void MoveToTarget(Tile tile) {
        path.Clear();
        tile.target = true;
        moving = true;

        Tile next = tile;
        while (next != null) {
            path.Push(next);
            next = next.parent;
        }
    }

    public void Move() {
        if (path.Count > 0) {
            Tile t = path.Peek();
            Vector3 target = t.transform.position;

            //target.y += piecePos;
            target.y = 0.51f;

            if (Vector3.Distance(transform.position, target) >= 0.05f) {

                CalculateHeading(target);
                SetVelocity();

                transform.forward = heading;
                transform.position += velocity * Time.deltaTime;

            } else {
                transform.position = target;
                path.Pop();
            }

        } else {

            RemoveTiles();
            moving = false;
        }
    }

    protected void RemoveTiles() {

        if (currentTile != null) {
            currentTile.current = false;
            currentTile = null;
        }

        foreach (Tile tile in tilesInRange) {
            tile.ResetSearch();
        }

        tilesInRange.Clear();
        Moved();
    }

    void CalculateHeading(Vector3 target) {
        heading = target - transform.position;
        heading.Normalize();
    }

    void SetVelocity() {
        velocity = heading * moveSpeed;
    }

    public void Attacked(){
        attacked = true;
    }

    public void Moved() {
        moved++;
    }

    public void TurnReset() {
        moved = 0;
        attacked = false;
    }

    public void CreatePath(Stack<Tile> p) {
        path = p;
    }

    public void SetPath(Stack<Tile> p) {
        path = p;
    }

    protected Tile FindLowestFcost(List<Tile> list) {
        Tile lowest = list[0];

        foreach(Tile t in list) {
            if(t.fCost < lowest.fCost) {
                lowest = t;
            }
        }

        list.Remove(lowest);

        return lowest;
    }

    protected Tile FindEndTile(Tile t) {
        Stack<Tile> tempPath = new Stack<Tile>();
        Tile next = t.parent;

        while(next != null) {
            tempPath.Push(next);
            next = next.parent;
        }

        if(tempPath.Count <= moveLimit) {
            return t.parent;
        }

        Tile endTile = null;
        for(int i = 0; i <= moveLimit; i++) {
            endTile = tempPath.Pop();
        }

        return endTile;
    }
}
