using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Animator anim;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        if (Input.GetKey(KeyCode.N))
        {
            anim.SetBool("Attacking", true);
        }
        else
        {
            anim.SetBool("Attacking", false);
        }

        if (Input.GetKey(KeyCode.T))
        {
            anim.SetInteger("DeathValue", 1);
        }
        else
        {
            anim.SetInteger("DeathValue", 0);
        }
    }
}
