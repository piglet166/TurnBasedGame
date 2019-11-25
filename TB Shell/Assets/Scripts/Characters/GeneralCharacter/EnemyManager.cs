using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public TurnManager grandma;
    List<EnemyMovement> pieces = new List<EnemyMovement>();
    public int myTurn;
	public GameObject myPrefab;

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
            //if(pieces[i].agro) 
            pieces[i].done = false;
        }
    }

    public void PlayTurn()
	{
        Debug.Log("Play Turn");
        foreach (EnemyMovement em in pieces)
		{
			em.FindNearestTarget();
            Debug.Log(em.target.transform.position);

			float playerDistance = Vector3.Distance(em.transform.position, em.target.transform.position);
			float threshold = 5f;
			bool wiseTarget = true;

			if (playerDistance < threshold)
			{
				cType mType = em.gameObject.GetComponent<CharacterType>().myType;
				cType tType = em.target.GetComponent<CharacterType>().myType;

				if (!(mType == tType))
				{
					if (!(mType == cType.tSword && tType == cType.tSpear))
					{
						if (!(mType == cType.tSpear && tType == cType.tHeavy))
						{
							if (!(mType == cType.tHeavy && tType == cType.tSword))
							{
								wiseTarget = false;
							}
						}
					}
				}
			}

			if (playerDistance > threshold || !wiseTarget)
			{
				Vector3 closestFriend = new Vector3(0, 0, 0);
				float closestDistance = Mathf.Infinity;

				foreach (EnemyMovement buddy in pieces)
				{
                    if (em.transform.position != buddy.transform.position)
					{
						float currentDistance = Vector3.Distance(em.transform.position, buddy.transform.position);

                        if (currentDistance < closestDistance)
						{
							closestFriend = buddy.transform.position;
							closestDistance = currentDistance;
						}
					}
				}
                    
				float xpos = em.transform.position.x + (closestFriend.x - em.transform.position.x)/2;
				float ypos = em.transform.position.y;
				float zpos = em.transform.position.z + (closestFriend.z - em.transform.position.z)/2;

				Instantiate(myPrefab, new Vector3(xpos, ypos, zpos), Quaternion.identity);
				em.target = myPrefab;
				Debug.Log(em.target.transform.position);
			}

			if (!(em.moving)) {
                em.FindPath();
                em.BreadthFirstSeach();
                em.actualTarget.target = true;
            }
		}

		Endturn();
	}

    public void Endturn() {
        grandma.FinishTurn(myTurn);

        for (int i = 0; i < pieces.Count; i++) {
            pieces[i].TurnReset();
        }
    }

    public bool MotherMayI(bool done) {
        if (grandma.GetTurn() > 0) {
            return false;
        } else if (done) {
            return false;
        //} else if (!agro) {
        //    return false;
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

    public void SelectPiece(EnemyMovement e) {
        foreach (EnemyMovement piece in pieces) {
            piece.clicked = false;
        }

        e.clicked = true;
    }
}
