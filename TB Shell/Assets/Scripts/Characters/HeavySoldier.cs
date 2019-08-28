using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySoldier : MonoBehaviour
{

    CharacterStats baseStats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BaseStats() {

        baseStats.Resistance = 1;
        baseStats.Agility = 1;
        baseStats.Damage = 1;
        baseStats.Endurance = 1;
        baseStats.Skill = 1;
    }
}
