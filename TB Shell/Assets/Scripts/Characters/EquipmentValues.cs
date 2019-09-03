using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentValues : MonoBehaviour
{
    public int armour;
    public int weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        weapon = 0;
        armour = 0;
    }

    public void UpdateArmour(int a) {
        armour = a;
    }

    public void UpdateWeapon(int w) {
        weapon = w;
    }

    public int getWeight() {
        int weight = armour + weapon;
        return weight;
    }

}
