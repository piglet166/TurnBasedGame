﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : MonoBehaviour{

    PlayerMove movement;
    CharacterType stats;
    //static Animator anim;

    cType swordsMan = cType.tSword;
    int vitality;
    int level = 1;
    int damage;
    int speed;
    int defense;
    int enemiesDefeated = 0;

    void Start() {
        vitality = 10;
        damage = 5;
        speed = 5;
        defense = 10;

        //anim = GetComponent<Animator>();

        movement = GetComponent<PlayerMove>();
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
    void Update() {

        /*if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isWalking");
        }*/
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

        movement.moveLimit = speed;
    }
        
}
