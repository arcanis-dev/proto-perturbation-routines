using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public string color;
    
    private MeshRenderer mr;
    public float flashTimer = 0.4f;
    public bool isFlashing = false;
    
    private void Start() {
        this.mr = this.GetComponent<MeshRenderer>();
    }
    
    public IEnumerator FlashCubeTimer(bool canFlash) {
        while (canFlash == true) {
            if (isFlashing) {
                GetComponent<MeshRenderer>().material.color = Color.white;
            }
            else {
                GetComponent<MeshRenderer>().material.color = new Color(0.329F,0.369F,0.859F,1.0F);
            }
            yield return new WaitForSeconds(flashTimer);
            isFlashing = !isFlashing;
        }
        
        
    }
}
