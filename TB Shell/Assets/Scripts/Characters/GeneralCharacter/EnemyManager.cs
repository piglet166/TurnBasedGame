using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public TurnManager grandma;
    List<EnemyMovement> pieces = new List<EnemyMovement>();
    public int myTurn;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject piece in GameObject.FindGameObjectsWithTag("Enemy")) {
            pieces.Add(piece.GetComponent<EnemyMovement>());
        }

        myTurn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (grandma.GetTurn() < 1) {
            return;
        }

        //we need code to ask whether the pieces are all done, if yes EndTurn()
        for(int i = 0; i < pieces.Count; i++) {
            if (!pieces[i].done) {
                break;
            }
        }

        //if not we need the enemy to PlayTurn();
        PlayTurn();
    }

    public void StartTurn() {
        for (int i = 0; i < pieces.Count; i++) {
            if(pieces[i].agro) pieces[i].done = false;
        }
    }

    //we may need a coroutine
    public void PlayTurn() {
        //pick the best piece
        
        //if pieces are already at the player Attack

        //if not already near a player, move towards the player

        //when piece is done, it's own "done" variable will turn true and piece will
        //not be picked up in the loop anymore.
    }

    public void Endturn() {
        grandma.FinishTurn(myTurn);

        for (int i = 0; i < pieces.Count; i++) {
            pieces[i].TurnReset();
        }
    }

    public bool MotherMayI(bool done, bool agro) {
        if (grandma.GetTurn() > 0) {
            return false;
        } else if (done) {
            return false;
        } else if (!agro) {
            return false;
        }else {
            return true;
        }
    }

    public void PieceGone(EnemyMovement p) {
        pieces.Remove(p);
    }

    public void PieceAdded(EnemyMovement p) {
        pieces.Add(p);
    }
}
