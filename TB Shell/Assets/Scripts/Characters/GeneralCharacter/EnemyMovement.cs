using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    public EnemyManager mother;
    bool mayI;
    public int attackStrength;
    public bool done;
    //public bool agro;
    //public Pathfinding AI;
    public bool clicked;

    public GameObject me;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        mayI = false;
        //agro = false;
        Init();
    }

   // update is called once per frame
   void Update() {
        if (moving) {
            Move();
        }

        isDone();
    }

	//	if (!agro)
	//	{
	//		Agro();
	//	}
	//}

    bool MotherMayI() {
        mayI = mother.MotherMayI(done);

        return mayI;
    }

    public void FindPath() {
        Tile targetTile = GetTarget(target);
        Astar(targetTile);
    }

    //Decision AI goes here!!!
    public void FindNearestTarget() {
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

    public void Agro() {
        //create a range
        
        //if player piece enters range
        //change agro to true;
        //Add piece to EnemyMangager pieces list;
        //enemy will keep attacking player until dead

        //else agro remains false (no need to change)
    }

    public void isDone() {
        if(moved > 1 || attacked) {
            done = true;
        }
    }
}
