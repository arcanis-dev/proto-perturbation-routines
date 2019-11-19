using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Agent1Behaviour : AgentBase {
    public HandlingScript hs;
    private Rigidbody rb;

    public Transform[] waypoints = new Transform[4];
    public Transform target;
    public List<Transform> path;
    
    private void Start() {
        rb = this.GetComponent<Rigidbody>();
        hs = this.GetComponent<HandlingScript>();
        this.target = this.waypoints[0];
    }

    private void Update() {
        switch (this.state) {
            case AgentStates.Routine :
//                if (!this.hs.hasCube) {
//                    SwitchState(AgentStates.Retablissement);
//                    break;
//                }
                
                if (this.path.Count > 0) {
                    if (this.target == null) {
                        //this.target = this.path[0];
                    }
                    Debug.Log("process");
                    ProcessPath();
                }
                else if (this.path.Count == 0) {
                    Debug.Log("set path");
                    this.SetPath();
                }

                break;
            case AgentStates.Retablissement:
                
                break;
        }
    }

    private void ProcessPath() {
        var newPosition = Vector3.MoveTowards(transform.position, this.target.position, speed * Time.deltaTime);
        Debug.Log("newPosition");
        this.rb.position = newPosition;
        transform.LookAt(this.target);
        
        //Si arrivé
        if (transform.position == this.target.position) {
            Debug.Log("Switch Target");

            //Addpoint
            for (int i = 0; i < this.waypoints.Length; i++) {
                if (this.waypoints[i] == this.target) {
                    if (this.waypoints[i] != this.waypoints[this.waypoints.Length - 1]) {
                        this.path.Add(this.waypoints[i++]);
                        Debug.Log("add 1");
                    }
                    else {
                        this.path.Add(this.waypoints[0]);
                        Debug.Log("add 2");
                    }
                    break;
                }
            }
            
            //Enlève du path le target
            this.path.Remove(this.target);
            
            this.target = this.path[0];
        }
    }

    private void SetPath() {
        for (int i = 0; i < this.waypoints.Length; i++) {
            this.path.Add(this.waypoints[i]);
            Debug.Log(i);
        }
    }

    protected override void OnEnterState() {
        switch (state) {
            case AgentStates.Routine:
                this.SetPath();
                break;
        }
        
    }

    protected override void OnExitState() {
        switch (state) {
            case AgentStates.Routine:
                this.path.Clear();
                break;
        }
    }
}
