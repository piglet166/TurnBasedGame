using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : CharacterController
{
    CharacterStats baseStats;
    private bool knocked;
    
    // Start is called before the first frame update
    void Start()
    {
        knocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BaseStats() {

        baseStats.Resistance = 1;
        baseStats.Agility = 4;
        baseStats.Power = 2;
        baseStats.Endurance = 3;
        baseStats.Skill = 5;
    }

    public void Knock() {
        knocked = true;
    }

    public void Release() {
        knocked = false;
    }

    public void Fire() {
        knocked = false;
    }

    
}
