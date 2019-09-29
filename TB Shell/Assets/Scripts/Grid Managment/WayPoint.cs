using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Tile tile;

    public int x, z;
    public bool occupied;
    
    // Start is called before the first frame update
    void Start()
    {
        tile.obstacle = false;
        tile.traversable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void traverse(GameObject customer) {

    }

    public void occupy() {


        occupied = true;
    }

    public void leave() {


        occupied = false;
    }

    public bool isOccupied() {
        return occupied;
    }
}
