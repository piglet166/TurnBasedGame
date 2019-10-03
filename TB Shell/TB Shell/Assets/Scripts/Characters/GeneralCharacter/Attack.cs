using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void AttackOther(cType type, cType target) {
        switch (type) {
            case cType.tNull:
                return;
            case cType.tArcher:
                break;
            case cType.tHeavy:
                break;
            case cType.tSpear:
                break;
            case cType.tSword:
                break;
            default:
                System.Console.WriteLine("no type found");
                break;

        }
    }
}
