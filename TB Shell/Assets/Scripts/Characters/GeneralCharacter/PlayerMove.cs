using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Movement
{
    public PlayerManager mother;
    public Attack attack;
    bool mayI;
    public int attackStrength;
    public bool done;
    public bool clicked;
    
    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<Attack>();
        mayI = false;
        clicked = false;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (MotherMayI() && clicked) {
            if (!moving) {
                BreadthFirstSeach();
                EnemyBFS();
                CheckMouse();
                PlayerInput();
                attack.Selected();

            } else {
                Move();
            }

            isDone();
        } else {
            
            clicked = false;
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
        mayI = mother.MotherMayI(done);

        return mayI;
    }

    public void isDone() {
        if (moved > 1 || attacked) {
            done = true;
        }
    }

    private void OnMouseDown() {
        mother.SelectPiece(this);
        attack.Selected();
    }
}
