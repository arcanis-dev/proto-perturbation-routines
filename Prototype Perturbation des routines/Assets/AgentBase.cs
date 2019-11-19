using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBase : MonoBehaviour {

    public float speed;
    public enum AgentStates {
        Routine,
        Retablissement
    }

    public AgentStates state;
    public AgentStates previousState;

    protected void SwitchState(AgentStates newState) {
        OnEnterState();
        previousState = this.state;
        state = newState;
        OnExitState();
    }

    virtual protected void OnEnterState() {
        
    }

    virtual protected void OnExitState() {
        
    }
    
    
    
}


