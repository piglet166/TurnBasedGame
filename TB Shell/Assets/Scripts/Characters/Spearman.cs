using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : ClassController
{

    void Start() {
        baseStats = GetComponent<CharacterStats>();
        BaseStats();
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
