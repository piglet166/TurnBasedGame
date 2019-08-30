using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassController : MonoBehaviour
{
    public CharacterStats baseStats;

    // Start is called before the first frame update
    void Start() {
        baseStats = GetComponent<CharacterStats>();
        BaseStats();
    }

    // Update is called once per frame
    void Update() {

    }

    private void BaseStats() { }

    private void Death(int h) {

        if (h <= 0) {
            Destroy(gameObject);
        }

    }
}
