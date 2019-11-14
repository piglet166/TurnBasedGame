using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : MonoBehaviour
{
    PlayerMove movement;
    CharacterType stats;

    cType spearMan = cType.tSpear;
    int vitality;
    int level = 1;
    int damage;
    int speed;
    int defense;
    int enemiesDefeated = 0;

    void Start() {
        vitality = 10;
        damage = 5;
        speed = 10;
        defense = 5;

        movement = GetComponent<PlayerMove>();
        movement.moveLimit = speed;
        movement.attackLimit = 1;
        movement.attackStrength = damage;

        stats = GetComponent<CharacterType>();
        stats.damage = damage;
        stats.health = vitality;
        stats.speed = speed;
        stats.defense = defense;
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
}
