using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Agent1Behaviour : AgentBase {
    public HandlingScript hs;
    private Rigidbody rb;

    public Transform[] waypoints = new Transform[4];
    public Transform target;
    public List<Transform> path;

    public GameObject targetStock;
    public GameObject targetCube;
    private StockController targetStockController;
    
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
                
                if (this.path.Count > 0) {
//                    if (this.target == null) {
//                        //this.target = this.path[0];
//                    }
                    Debug.Log("process");
                    ProcessPath();
                }
                else if (this.path.Count == 0) {
                    Debug.Log("set path");
                    this.SetPath(true);
                }
                break;
            
            case AgentStates.Retablissement:
                //Va chercher un cube sur la pile
                this.ProcessPath();

                
                if (this.targetStockController.cubesNumber > 0) {
                    if (this.targetCube != null) {
                        this.hs.TakeCube(this.targetCube);
                    }
                    else {
                        this.targetStockController.GetCubeByColor("blue");
                    }
                }
                else {
                    this.targetCube = null;
                    this.target = null;
                    this.hs.TakeCube();
                }

                if (this.hs.hasCube) {
                    SwitchState(AgentStates.Routine);
                }

                break;
        }
    }

    private void ProcessPath() {
        var newPosition = Vector3.MoveTowards(transform.position, this.target.position, speed * Time.deltaTime);
        this.rb.position = newPosition;
        transform.LookAt(this.target);
        
        //Si arrivé
        if (transform.position == this.target.position) {
            Debug.Log("Switch Target");
            
            GetFirstToLast(this.path);
            
            this.target = this.path[0];
        }
    }

    private void GetFirstToLast<T>(List<T> list) {
        T temp = list[0];
        list.RemoveAt(0);
        list.Add(temp);
    }

    private void SetPath(bool random = false) {
        for (int i = 0; i < this.waypoints.Length; i++) {
            this.path.Add(this.waypoints[i]);
        }
        
        if (random == true) {
            var sortNumber = Random.Range(0, this.waypoints.Length);
            for (int i = 0; i < sortNumber; i++) {
                GetFirstToLast(this.path);
            }
        }

        this.target = this.path[0];
    }

    protected override void OnEnterState() {
        switch (state) {
            case AgentStates.Routine:
                this.SetPath(true);
                break;
            case AgentStates.Retablissement:
                targetStockController = this.targetStock.GetComponent<StockController>();
                if (this.targetStockController.cubesNumber > 0) {
                    this.targetCube = this.targetStockController.GetCubeByColor("blue");
                    this.target = this.targetCube.transform;
                    this.path.Add(this.targetCube.transform);
                }
                break;
        }
        
    }

    protected override void OnExitState() {
        switch (state) {
            case AgentStates.Routine:
                this.path.Clear();
                break;
            case AgentStates.Retablissement:
                this.path.Clear();
                break;
        }
    }
}
