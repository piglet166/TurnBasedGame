using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Movement
{
    public TurnManager mother;
    int myTurn;
    bool mayI;
    public int attackStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        myTurn = 0;
        mayI = false;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (MotherMayI()) {
            if (!moving) {
                BreadthFirstSeach();
                EnemyBFS();
                CheckMouse();
                PlayerInput();

            } else {
                Move();
            }

            EndTurn();
        }
    }

    void CheckMouse() {
        if (Input.GetMouseButtonUp(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider.tag == "Tile") {
                    Tile t = hit.collider.GetComponent<Tile>();

                    if (t.selectable) {
                        MoveToTarget(t);
                    }
                }
            }
        }
    }

    void PlayerInput() {
        if (Input.GetMouseButtonUp(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider.tag == "Enemy") {
                    CharacterType enemy = hit.collider.GetComponent<CharacterType>();

                    if (enemy.inRange) {
                        enemy.TakeDamage(attackStrength);
                        Attacked();
                    }
                }
            }
        }
    }

    bool MotherMayI() {
        if (mother.GetTurn() > myTurn) {
            mayI = false;
        } else {
            mayI = true;
        }

        return mayI;
    }

    void EndTurn() {
        if(moved > 1) {
            mother.FinishTurn(myTurn);
            TurnReset();
            Debug.Log("Turn Ended");
        }else if(attacked) {
            mother.FinishTurn(myTurn);
            TurnReset();
            Debug.Log("Turn Ended");
        }
    }

    void EndTurn(bool command) {
        if (command) {
            mother.FinishTurn(myTurn);
            TurnReset();
        }
    }
}
