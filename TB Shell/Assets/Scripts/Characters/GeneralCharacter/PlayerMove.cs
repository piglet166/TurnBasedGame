using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Movement
{
    public TurnManager mother;
    int myTurn;
    bool mayI;
    
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
                CheckMouse();

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
            MovementBugCatcher(true);
        }
    }

    bool MotherMayI() {
        if (mother.GetTurn() > myTurn) {
            mayI = false;
            Debug.Log("No");
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
        }else if(moved > 0 && attacked) {
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
