using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Agent1Behaviour : AgentBase {
    public HandlingScript hs;
    private Rigidbody rb;

    public Transform[] waypoints = new Transform[4];

    public List<Vector3> Path;

    private void Start() {
        rb = this.GetComponent<Rigidbody>();
        hs = this.GetComponent<HandlingScript>();
    }

    private void Update() {
        switch (this.state) {
            case AgentStates.Routine :

                if (!this.hs.hasCube) {
                    SwitchState(AgentStates.Retablissement);
                    break;
                }
                
                if (Path.Count > 0) {
                    if (this.Path.Count == 1) {
                        this.AddPath();
                    }
                    ProcessPath();
                }


                break;
            case AgentStates.Retablissement:
                
                break;
        }
    }

    private void ProcessPath() {
        if (transform.position == this.Path[0]) {
            this.Path.RemoveAt(0);
        }
        rb.MovePosition(this.Path[0]);
    }

    private void AddPath() {
        for (int i = 0; i < this.waypoints.Length; i++) {
            if (this.waypoints[i].position == this.Path[0]) {
                this.Path.Add(this.waypoints[i] == this.waypoints.Last()
                    ? this.waypoints[0].position
                    : this.waypoints[i++].position);
            }
        }
    }

    private void SetPath() {
        for (int i = 0; i < this.waypoints.Length; i++) {
            
        }
    }
    
    
}
