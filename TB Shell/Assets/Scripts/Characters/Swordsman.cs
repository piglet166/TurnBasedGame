using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : ClassController{

    void Start() {
        baseStats = GetComponent<CharacterStats>();
        BaseStats();
    }
    // Update is called once per frame
    void Update() {

    }
    
    private void BaseStats() {

        baseStats.Resistance = 5;
        baseStats.Agility = 3;
        baseStats.Power = 2;
        baseStats.Endurance = 4;
        baseStats.Skill = 1;
    }
        
}
