using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.XR;

public class HandlingScript : MonoBehaviour {
    public Transform hand;
    private ReachScript rs;
    public GameObject cubeInHand;
    private Rigidbody cubeRb;
    
    public bool hasCube;
    public float throwForce;
    
    
    void Start() {
        this.hand = transform.Find("Hand");
        this.rs = transform.Find("HandReach").GetComponent<ReachScript>();
    }

    public void TakeCube(GameObject targetCube = null) {
        if (this.rs.cubes.Count > 0) {
            if (targetCube == null) {
                this.cubeInHand = this.rs.cubes[0];
                GetCubeInHand();
            }
            else {
                foreach (var cube in this.rs.cubes) {
                    if (cube == targetCube) {
                        this.cubeInHand = cube;
                        GetCubeInHand();
                        break;
                    }
                }
            }
        }
    }

    public void ThrowCube() {
        cubeRb = this.cubeInHand.GetComponent<Rigidbody>();
        cubeRb.isKinematic = false;
        cubeRb.AddForce(this.hand.forward * throwForce, ForceMode.Impulse);
        this.cubeInHand.GetComponent<Collider>().enabled = true;
        this.rs.cubes.Remove(this.cubeInHand);
        Debug.Log("cuberemoved");
        this.cubeInHand = null;
        this.hasCube = false;
    }

    public void StealCube() {
        GetCubeInHand();
    }

    public void MoveHand(Vector3 newHandPosition, Quaternion newHandRotation) {
        this.hand.position = newHandPosition;
        this.hand.rotation = newHandRotation;

    }

    public void GetCubeInHand() {
        this.cubeRb = this.cubeInHand.GetComponent<Rigidbody>();
        this.cubeRb.isKinematic = true;
        this.cubeInHand.GetComponent<Collider>().enabled = false;
        this.hasCube = true;
    }

    private void FixedUpdate() {
        if (this.hasCube) {
            this.cubeInHand.GetComponent<Rigidbody>().position = this.hand.position;
        }
    }
}
