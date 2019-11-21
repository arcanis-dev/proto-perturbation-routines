using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {
    public Color baseColor;
    public string color;
    
    private MeshRenderer mr;
    public float flashTimer = 2f;
    public bool isFlashing = false;
    public bool canFlash = true;

    public IEnumerator flashRoutine;
    
    private void Start() {
        
        this.mr = this.GetComponent<MeshRenderer>();
        this.baseColor = this.mr.material.color;
    }
    
    public IEnumerator FlashCubeTimer() {
        while (canFlash) {
            
            if (isFlashing) {
                mr.material.color = Color.white;
            }
            else {
                mr.material.color = this.baseColor;
            }
            
            isFlashing = !isFlashing;
            
            yield return new WaitForSeconds(flashTimer);
        }

        this.mr.material.color = this.baseColor;
        Debug.Log("coroutine ended");
    }
}
