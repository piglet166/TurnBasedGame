using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    public TurnManager mother;
    int myTurn;
    bool mayI;
    public int attackStrength;
    public Pathfinding AI;

    public GameObject StartPosition;
    public GameObject TargetPosition;

    // Start is called before the first frame update
    void Start()
    {
        myTurn = 1;
        mayI = false;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (MotherMayI()) {
            if (!moving) {
                AI.FindPath(StartPosition, TargetPosition);

            } else {
                Move();
            }

            EndTurn();
        }
    }

    bool MotherMayI() {
        if (mother.GetTurn() < myTurn) {
            mayI = false;
        } else {
            mayI = true;
        }

        return mayI;
    }

    void EndTurn() {
        if (moved > 1) {
            mother.FinishTurn(myTurn);
            TurnReset();
            Debug.Log("Enemy Done");
        } else if (attacked) {
            mother.FinishTurn(myTurn);
            TurnReset();
            Debug.Log("Enemy Done");
        }
    }
}
