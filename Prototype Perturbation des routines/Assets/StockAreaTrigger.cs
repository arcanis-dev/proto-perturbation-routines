using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockAreaTrigger : MonoBehaviour {
    private StockController sc;

    private void Awake() {
        this.sc = this.GetComponentInParent<StockController>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Cube")) {
            this.sc.cubes.Add(other.gameObject);
            this.sc.UpdateCubesNumber();
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Cube")) {
            this.sc.cubes.Remove(other.gameObject);
            this.sc.UpdateCubesNumber();
        }
        
    }
}
