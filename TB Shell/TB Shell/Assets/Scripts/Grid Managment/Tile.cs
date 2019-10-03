using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public List<Tile> surrondingTiles = new List<Tile>();
    public Material defMat;

    public bool obstacle;
    public bool traversable = true;
    public bool current = false;
    public bool target = false;
    public bool selectable = false;

    //Search variables
    public bool visited = false;
    public Tile parent = null;
    public int heuristic = 0;
    public int tilesMoved = 0;

    void Start() {
        
    }

    void Update() {

        if (obstacle) {
            return;
        }
        else if (current) {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (target) {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (selectable) {
            GetComponent<Renderer>().material.color = Color.cyan;
        } else {
            GetComponent<Renderer>().material = defMat;
        }
    }

    public void FindSurroundingTiles() {
        ResetSearch();

        CheckTile(Vector3.forward);
        CheckTile(-Vector3.forward);
        CheckTile(Vector3.right);
        CheckTile(-Vector3.right);
    }

    public void ResetSearch() {
        surrondingTiles.Clear();

        current = false;
        target = false;
        selectable = false;
        visited = false;
        parent = null;
        tilesMoved = 0;
    }

    public void CheckTile(Vector3 direction) {
        Vector3 halfExtends = new Vector3(.25f, ((1 + 2)/2f), .25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtends);

        foreach (Collider item in colliders) {
            Tile tile = item.GetComponent<Tile>();

            if(tile != null && tile.traversable) {
                RaycastHit hit;

                if (!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1)) {

                    surrondingTiles.Add(tile);
                }
            }
        }
    }

}
