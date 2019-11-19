using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerController : MonoBehaviour {
    private HandlingScript hs;
    private Camera cam;
    public float handOffset;

    private void Start() {
        this.hs = this.GetComponent<HandlingScript>();
        this.cam = Camera.main;
    }

    void Update() {
        this.hs.MoveHand(cam.transform.position + this.cam.transform.forward, this.cam.transform.rotation);
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!hs.hasCube) {
                this.hs.TakeCube();
            }
            else if(hs.hasCube){
                this.hs.ThrowCube();
            }
        }
    }
    
}
