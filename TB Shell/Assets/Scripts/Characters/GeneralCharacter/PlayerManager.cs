using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public TurnManager grandma;
    List<PlayerMove> pieces = new List<PlayerMove>();
    public int myTurn;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject piece in GameObject.FindGameObjectsWithTag("Player")) {
            pieces.Add(piece.GetComponent<PlayerMove>());
        }

        myTurn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(grandma.GetTurn() > 0) {
            return;
        }

        foreach(PlayerMove piece in pieces) {
            if (!piece.done) {
                return;
            }
        }

        Endturn();
    }

    public void StartTurn() {
        for(int i = 0; i < pieces.Count; i++) {
            pieces[i].done = false;
        }
    }

    public void Endturn() {
        grandma.FinishTurn(myTurn);

        for (int i = 0; i < pieces.Count; i++) {
            pieces[i].TurnReset();
        }
    }

    void EndTurn(bool command) {
        if (command) {
            grandma.FinishTurn(0);
            
            for(int i = 0; i < pieces.Count; i++) {
                pieces[i].TurnReset();
            }
        }
    }

    public bool MotherMayI(bool done) {
        if(grandma.GetTurn() > 0) {
            return false;
        }else if (done) {
            return false;
        }else {
            return true;
        }
    }

    public void PieceGone(PlayerMove p) {
        pieces.Remove(p);
    }

    public void PieceAdded(PlayerMove p) {
        pieces.Add(p);
    }

    public void SelectPiece(PlayerMove p) {
        foreach(PlayerMove piece in pieces) {
            piece.clicked = false;
        }

        p.clicked = true;
    }
}
