using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject hitObject = hitInfo.collider.transform.gameObject;

            Debug.Log("Raycast hit: " + hitObject.name);

            if (Input.GetMouseButtonDown(0))
            {
                MeshRenderer mr = hitObject.GetComponentInChildren<MeshRenderer>();

                if (mr.material.color == Color.red)
                {
                    mr.material.color = Color.white;
                }
                else
                {
                    mr.material.color = Color.red;
                }
            }
        }
    }
}
