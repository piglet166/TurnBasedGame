﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionExit(Collision collision) {
        Destroy(gameObject);
    }
}
