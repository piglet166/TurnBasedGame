using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    List<CharacterType> enemiesInRange = new List<CharacterType>();
    GameObject[] enemies;

    Movement pieceMove;
    cType type;
    
    public int attackLimit;
    float piecePos = 0;

    private void Start() {
        pieceMove = GetComponent<Movement>();

        type = GetComponent<CharacterType>().myType;
    }

    private void Update() {
        
    }

    void EnemySearch() {
        ResetEnemySearch();

        CheckEnemies(Vector3.forward);
        CheckEnemies(-Vector3.forward);
        CheckEnemies(Vector3.right);
        CheckEnemies(-Vector3.right);
    }

    private void ResetEnemySearch() {
        enemiesInRange.Clear();
    }

    void CheckEnemies(Vector3 direction) {
        Vector3 halfExtends = new Vector3(.25f, ((1 + 2) / 2f), .25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtends);

        foreach (Collider item in colliders) {
            Tile tile = item.GetComponent<Tile>();

            if (tile != null && tile.traversable) {
                RaycastHit hit;

                if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1) &&
                    hit.transform.tag == "Enemy") {
                    CharacterType e;
                    e = hit.collider.gameObject.GetComponent<CharacterType>();
                    e.inRange = true;

                    enemiesInRange.Add(e);

                    tile.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
    }

    public void Selected() {

        if (pieceMove.attacked) return;

        EnemySearch();
    }

    public void Fight(cType target, CharacterType health) {

        switch (target) {
            case cType.tNull:
                Debug.Log("Something's wrong");
                return;
            case cType.tArcher:
                Debug.Log("There shouldn't be an archer");
                break;
            case cType.tHeavy:

                switch (type) {
                    case cType.tHeavy:
                        break;
                    case cType.tSpear:
                        break;
                    case cType.tSword:
                        break;
                    default:
                        Debug.Log("put the type in the prefab");
                        break;
                }

                break;
            case cType.tSpear:

                switch (type) {
                    case cType.tHeavy:
                        break;
                    case cType.tSpear:
                        break;
                    case cType.tSword:
                        break;
                    default:
                        Debug.Log("put the type in the prefab");
                        break;
                }

                break;
            case cType.tSword:

                switch (type) {
                    case cType.tHeavy:
                        break;
                    case cType.tSpear:
                        break;
                    case cType.tSword:
                        break;
                    default:
                        Debug.Log("put the type in the prefab");
                        break;
                }

                break;
            default:
                System.Console.WriteLine("no type found");
                break;
        }
    }
}
