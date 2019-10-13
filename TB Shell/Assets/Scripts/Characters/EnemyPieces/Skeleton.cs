using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    CharacterType stats;
    
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<CharacterType>();
        stats.health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
