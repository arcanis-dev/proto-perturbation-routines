using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.XR;

public class ReachScript : MonoBehaviour {
    public List<GameObject> Cubes;
    public Collider handReach;
    public float flashTimer = 0.4f;
    private void Start() {
        this.handReach = this.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Cube")) {
            this.Cubes.Add(other.gameObject);
            
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Cube")) {
            other.gameObject.GetComponent<CubeScript>().FlashCubeTimer(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Cube")) {
            if (this.Cubes.Contains(other.gameObject)) {
                this.Cubes.Remove(other.gameObject);
            }
        }
    }
}
