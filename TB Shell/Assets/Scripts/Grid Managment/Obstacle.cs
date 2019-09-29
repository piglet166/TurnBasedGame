using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Tile tile;
    
    // Start is called before the first frame update
    void Start()
    {
        tile.obstacle = true;
        tile.traversable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
