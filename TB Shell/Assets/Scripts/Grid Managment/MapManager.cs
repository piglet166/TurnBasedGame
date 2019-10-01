using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject hexPrefab;

    //Size of map in terms of Hex tile size,
    //NOT representative of world space
    //(tiles might be more or less than 1 Unity World unit)
    int width = 20;
    int height = 20;

    float xOffset = 1.03f;
    float zOffset = 0.892f;
    
    
    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x * xOffset;

                //If on an odd row..
                if (y % 2 == 1)
                {
                    xPos += xOffset/2f;
                }
                //setting position with no rotation
                GameObject hex_GO = (GameObject)Instantiate(hexPrefab, new Vector3 (xPos, 0, y * zOffset), Quaternion.identity);

                //Organization
                hex_GO.name = "Hex_" + x + "_" + y;

                //Organization
                hex_GO.transform.SetParent(this.transform);
            }
        }


    }

    
    void Update()
    {



    }
}
