using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent1Behaviour : MonoBehaviour {
    private Transform hand;

    private void Start() {
        this.hand = transform.Find("Hand");
    }
    
    
}
