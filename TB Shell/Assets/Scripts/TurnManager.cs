using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum turn { Player, AI };

public class TurnManager : MonoBehaviour
{
    int turn;
    
    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (turn > 0) {
            //Debug.Log("Enemy Turn");
        } else {
            //Debug.Log("Player Turn");

        }
    }

    public void FinishTurn(int t) {
        if(t > 0) {
            turn = 0;
        } else {
            turn++;
        }
    }

    public int GetTurn() {
        return turn;
    }
}
