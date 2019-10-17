using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    public TurnManager mother;
    int myTurn;
    bool mayI;
    public int attackStrength;
    //public Pathfinding AI;

    public GameObject me;
    public GameObject target;

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
                FindNearestTarget();
                FindPath();
                BreadthFirstSeach();
                actualTarget.target = true;

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

    void FindPath() {
        Tile targetTile = GetTarget(target);
        Astar(targetTile);
    }

    //Decision AI goes here!!!
    void FindNearestTarget() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach(GameObject candidates in targets) {
            float d = Vector3.Distance(transform.position, candidates.transform.position);

            if(d < distance) {
                distance = d;
                nearest = candidates;
            }
        }

        target = nearest;
    }
}
