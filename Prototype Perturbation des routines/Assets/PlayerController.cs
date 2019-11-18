using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private HandlingScript hs;

    private void Start() {
        this.hs = this.GetComponent<HandlingScript>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!hs.hasCube) {
                hs.TakeCube();
            }
            else if(hs.hasCube){
                hs.ThrowCube();
            }
        }
    }
}
