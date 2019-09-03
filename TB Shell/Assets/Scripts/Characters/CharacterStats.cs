using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    
    [SerializeField]
    private EquipmentValues equipment;

    [Header("Base Stats")]
    public int Resistance;
    public int Agility;
    public int Power;
    public int Endurance;
    public int Skill;

    [Header("Character Stats")]
    [SerializeField]
    private int health, speed, minDamage, maxDamage, parryChance;

    void Start() {
        equipment = GetComponent<EquipmentValues>();

        
        initHealth();
        initSpeed(equipment.armour, equipment.weapon);
        initPower(equipment.weapon);
        initParryChance();
    }

    public void initBaseStats(int r, int a, int p, int e, int s) {
        Resistance = r;
        Agility = a;
        Power = p;
        Endurance = e;
        Skill = s;

    }

    private void initHealth() {
        health = Resistance * 4;
    }
    private void initSpeed(int armour, int weapon) {
        speed = (Agility * 2);//- (controller.turnWeight(armour, weapon) / Endurance);
    }
    private void initPower(int weapon) {
        maxDamage = Power + weapon;
        minDamage = maxDamage - (maxDamage / 4);
    }
    private void initParryChance() {
        parryChance = (Skill / 2) * 10;
    }

    
}
