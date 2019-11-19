﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.XR;

public class HandlingScript : MonoBehaviour {
    public Transform hand;
    private ReachScript rs;
    private GameObject cubeInHand;
    
    public bool hasCube;
    public float throwForce;
    
    
    void Start() {
        this.hand = transform.Find("Hand");
        this.rs = transform.Find("HandReach").GetComponent<ReachScript>();
    }

    public void TakeCube() {
        if (this.rs.Cubes.Count > 0) {
            this.cubeInHand = this.rs.Cubes[0];
            this.cubeInHand.transform.position = this.hand.position;
            this.cubeInHand.GetComponent<Rigidbody>().useGravity = false;
            this.hasCube = true;
        }
    }

    public void ThrowCube() {
        var cubeRb = this.cubeInHand.GetComponent<Rigidbody>();
        cubeRb.useGravity = true;
        cubeRb.AddForce(this.hand.forward * throwForce, ForceMode.Impulse);
        this.hasCube = false;
    }

    public void StealCube() {
        
    }

    public void MoveHand(Vector3 newHandPosition, Quaternion newHandRotation) {
        this.hand.position = newHandPosition;
        this.hand.rotation = newHandRotation;

    }

    private void FixedUpdate() {
        if (this.hasCube) {
            this.cubeInHand.transform.position = this.hand.position;
        }
        
    }
}
