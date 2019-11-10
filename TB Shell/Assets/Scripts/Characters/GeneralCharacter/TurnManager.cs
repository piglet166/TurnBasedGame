using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum turn { Player, AI };

public class TurnManager : MonoBehaviour
{
    public static List<EnemyMovement> enemies = new List<EnemyMovement>();
    public static List<PlayerMove> players = new List<PlayerMove>();
    int turn;

    // Start is called before the first frame update
    void Start()
    {
        turn = 0;

        GameObject[] ego = GameObject.FindGameObjectsWithTag("Enemies");
        GameObject[] pgo = GameObject.FindGameObjectsWithTag("Player");

        for(int i = 0;  ego.Length > 0; i++) {
            enemies.Add(ego[i].GetComponent<EnemyMovement>());
        }

        for (int i = 0; pgo.Length > 0; i++) {
            players.Add(pgo[i].GetComponent<PlayerMove>());
        }
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
        if (t > 0) {
            turn = 0;
        }else if(turn <= 0) {
            turn = 1;
        } else {
            Debug.Log("Turn Manager is messed up " + turn);
        }
    }

    public int GetTurn() {
        return turn;
    }
}
