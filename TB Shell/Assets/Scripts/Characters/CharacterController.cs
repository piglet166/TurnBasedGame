using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    
    CharacterStats stats;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Death(int h) {

        if (h <= 0) {
            Destroy(gameObject);
        }

    }

    public int turnWeight(int armour, int weapon) {
        int weight = armour + weapon;

        return weight;
    }
}
