using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : CharacterController
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

        baseStats.Resistance = 2;
        baseStats.Agility = 5;
        baseStats.Power = 4;
        baseStats.Endurance = 1;
        baseStats.Skill = 3;
    }
}
