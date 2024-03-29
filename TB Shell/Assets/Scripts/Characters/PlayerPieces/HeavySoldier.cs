﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySoldier : MonoBehaviour
{
    cType heavySoldier = cType.tHeavy;
    int vitality = 10;
    int health;
    int level = 1;
    int damage;
    int speed;
    int defense;
    int enemiesDefeated = 0;

    void Start() {
        health = vitality;
        damage = 10;
        speed = 5;
        defense = 5;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Experience() {
        enemiesDefeated++;

        if (enemiesDefeated >= level * 2) LevelUp();
    }

    void LevelUp() {
        level++;
        enemiesDefeated = 0;

        vitality++;
        damage++;
        speed++;
        defense++;
    }

    void TakeDamage(int attack) {
        health = health + (defense / 2) - attack;
    }

    void Attack() {

    }
}
