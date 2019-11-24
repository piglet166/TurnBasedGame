using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    CharacterType stats;
    EnemyMovement movement;

    cType swordsMan = cType.tSword;
    int vitality;
    int level = 1;
    int damage;
    int speed;
    int defense;
    int enemiesDefeated = 0;

    // Start is called before the first frame update
    void Start()
    {
        vitality = 10;
        damage = 5;
        speed = 5;
        defense = 10;

        movement = GetComponent<EnemyMovement>();
        movement.moveLimit = speed;
        movement.attackLimit = 1;
        movement.attackStrength = damage;

        stats = GetComponent<CharacterType>();
        stats.damage = damage;
        stats.health = vitality;
        stats.speed = speed;
        stats.defense = defense;
        stats.myType = swordsMan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack() {

    }

    void Parry() {

    }
}
