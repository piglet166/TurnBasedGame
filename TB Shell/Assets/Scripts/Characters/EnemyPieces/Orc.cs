using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    CharacterType stats;
    EnemyMovement movement;

    cType orc = cType.tHeavy;
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

        //anim = GetComponent<Animator>();

        movement = GetComponent<EnemyMovement>();
        movement.moveLimit = speed;
        movement.attackLimit = 1;
        movement.attackStrength = damage;

        stats = GetComponent<CharacterType>();
        stats.damage = damage;
        stats.health = vitality;
        stats.speed = speed;
        stats.defense = defense;
        stats.myType = orc;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
