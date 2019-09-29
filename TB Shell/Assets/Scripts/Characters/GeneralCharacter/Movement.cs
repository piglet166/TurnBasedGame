using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    List<Tile> tilesInRange = new List<Tile>();
    Stack<Tile> path = new Stack<Tile>();
    GameObject[] tiles;

    Vector3 velocity = new Vector3();
    Vector3 heading = new Vector3();
    Tile currentTile;

    public bool moving;
    public int moveLimit;
    int moveSpeed = 2;
    float piecePos = 0;

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

        if(Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1)) {
            tile = hit.collider.GetComponent<Tile>();
        }
        return tile;
    }

    public void CreateSurrTileList() {
        foreach(GameObject tile in tiles) {
            Tile t = tile.GetComponent<Tile>();
            t.FindSurroundingTiles();
        }
    }

    public void BreadthFirstSeach() {
        CreateSurrTileList();
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
        if(path.Count > 0) {
            Tile t = path.Peek();
            Vector3 target = t.transform.position;

            //target.y += piecePos;
            target.y = 0.51f;

            if(Vector3.Distance(transform.position, target) >= 0.05f) {

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

        if(currentTile != null) {
            currentTile.current = false;
            currentTile = null;
        }

        foreach(Tile tile in tilesInRange) {
            tile.ResetSearch();
        }

        tilesInRange.Clear();
    }

    void CalculateHeading(Vector3 target) {
        heading = target - transform.position;
        heading.Normalize();
    }

    void SetVelocity() {
        velocity = heading * moveSpeed;
    }
}
