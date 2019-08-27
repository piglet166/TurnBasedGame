using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterController controller;

    [Header("Base Stats")]
    public int Resistance;
    public int Agility;
    public int Damage;
    public int Endurance;
    public int Skill;

    [Header("Character Stats")]
    [SerializeField]
    private int health, speed, minDamage, maxDamage, parryChance;

    //[Header("Turn Effects")]
    //public int damageRecieved;
    //public int weaponDamageChange;
    //public int armourChange;
    //public int weaponSpeedChange;

    private void initHealth() {
        health = Resistance * 4;
    }
    private void initSpeed(int armour, int weapon) {
        speed = (Agility * 2) - (controller.turnWeight(armour, weapon) / Endurance);
    }
    private void initDamage(int weapon) {
        maxDamage = Damage + weapon;
        minDamage = maxDamage - (maxDamage / 4);
    }
    private void initParryChance() {
        parryChance = (Skill / 2) * 10;
    }
}
