using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySoldier : CharacterController
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

        baseStats.Resistance = 4;
        baseStats.Agility = 2;
        baseStats.Power = 5;
        baseStats.Endurance = 1;
        baseStats.Skill = 3;
    }
}
