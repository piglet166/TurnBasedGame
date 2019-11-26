using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    List<CharacterType> enemiesInRange = new List<CharacterType>();
    GameObject[] enemies;

    public GameObject icon;
    PlayerMove pieceMove;
    cType type;
    
    public int attackLimit;
    float piecePos = 0;
    public bool attacking = false;

    private void Start() {
        pieceMove = GetComponent<PlayerMove>();

        type = GetComponent<CharacterType>().myType;

    }

    private void Update() {
        if (pieceMove.clicked) {
            if (attacking) {
                EnemySearch();

                foreach (CharacterType e in enemiesInRange) {
                    Transform initVec = e.transform;

                    Instantiate(icon, initVec);
                }
            }
        } else {
            attacking = false;
        }
    }

    void EnemySearch() {
        ResetEnemySearch();

        CheckEnemies(Vector3.forward);
        CheckEnemies(-Vector3.forward);
        CheckEnemies(Vector3.right);
        CheckEnemies(-Vector3.right);
    }

    private void ResetEnemySearch() {
        foreach(CharacterType e in enemiesInRange) {
            e.inRange = false;
        }

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
                }
            }
        }
    }

    public void Selected() {

        if (pieceMove.attacked) return;

        if (Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.tag == "Enemy") {
                    CharacterType enemy = hit.collider.GetComponent<CharacterType>();

                    if (enemy.inRange) {
                        Fight(enemy);
                        pieceMove.Attacked();
                    }
                }
            }
        }

    }

    public void Fight(CharacterType target) {

        switch (target.myType) {
            case cType.tNull:
                Debug.Log("Something's wrong");
                return;
            case cType.tArcher:
                Debug.Log("There shouldn't be an archer");
                break;
            case cType.tHeavy:

                switch (type) {
                    case cType.tHeavy:
                        target.TakeDamage(5);
                        break;
                    case cType.tSpear:
                        target.TakeDamage(3);
                        break;
                    case cType.tSword:
                        target.TakeDamage(8);
                        break;
                    default:
                        Debug.Log("put the type in the prefab");
                        break;
                }

                break;
            case cType.tSpear:

                switch (type) {
                    case cType.tHeavy:
                        target.TakeDamage(8);
                        break;
                    case cType.tSpear:
                        target.TakeDamage(5);
                        break;
                    case cType.tSword:
                        target.TakeDamage(3);
                        break;
                    default:
                        Debug.Log("put the type in the prefab");
                        break;
                }

                break;
            case cType.tSword:

                switch (type) {
                    case cType.tHeavy:
                        target.TakeDamage(3);
                        break;
                    case cType.tSpear:
                        target.TakeDamage(8);
                        break;
                    case cType.tSword:
                        target.TakeDamage(5);
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
