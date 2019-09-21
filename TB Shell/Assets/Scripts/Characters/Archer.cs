using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    cType archer = cType.tArcher;
    private bool knocked = false;

    void Start() {

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Knock() {
        knocked = true;
    }

    public void Release() {
        knocked = false;
    }

    public void Fire() {
        knocked = false;
    }

    
}
