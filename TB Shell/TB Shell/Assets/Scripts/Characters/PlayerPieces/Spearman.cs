using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : MonoBehaviour
{
    cType spearMan = cType.tSpear;
    int vitality = 10;
    int health;
    int level = 1;
    int damage;
    int speed;
    int defense;
    int enemiesDefeated = 0;

    void Start() {
        health = vitality;
        damage = 5;
        speed = 10;
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

    void CounterAttack() {

    }

    void Throw() {

    }
}
