using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cType { tArcher, tHeavy, tSpear, tSword, tNull };

public class CharacterType : MonoBehaviour
{

    [SerializeField] Animator animator;

    public bool inRange = false;
    public int health;
    public int damage;
    public int level;
    public int speed;
    public int defense;
    public cType myType;

    //public bool current = false;
    public bool target = false;
    public bool selectable = false;
    //public bool visited = false;
    //public CharacterType parent;

    private void Start() {
        health = 1;
    }

    private void Update() {
        if (health <= 0) Death();
    }

    public void TakeDamage(int attack) {
        health -= attack;
        Debug.Log("I'm hit!");
    }

    void Death() {
        //Play dying animation
        animator.SetInteger("DeathValue", 1);
        StartCoroutine(ResetDeathValue());

        Destroy(gameObject);
    }

    IEnumerator ResetDeathValue()
    {
        yield return null;
        animator.SetInteger("DeathValue", 1);
    }
    
}
