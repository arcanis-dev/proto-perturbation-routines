using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.XR;

public class ReachScript : MonoBehaviour {
    public List<GameObject> cubes;
    public Collider handReach;
    private void Start() {
        this.handReach = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Cube")) {
            Debug.Log("cube entered");
            this.cubes.Add(other.gameObject);

            if (transform.parent.gameObject.tag == "Player") {
                CubeScript cs = other.gameObject.GetComponent<CubeScript>();
                cs.flashRoutine = cs.FlashCubeTimer();
                cs.canFlash = true;
                StartCoroutine(cs.flashRoutine);
            }

        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Cube")) {
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Cube")) {
            if (this.cubes.Contains(other.gameObject)) {
                CubeScript cs = other.gameObject.GetComponent<CubeScript>();
                cs.canFlash = false;
                this.cubes.Remove(other.gameObject);
            }
        }
    }
}
