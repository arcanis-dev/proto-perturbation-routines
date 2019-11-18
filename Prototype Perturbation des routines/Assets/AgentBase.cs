using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBase : MonoBehaviour{
    public enum AgentStates {
        Routine,
        Retablissement
    }

    public AgentStates state = new AgentStates();

    protected void SwitchState(AgentStates newState) {
        OnEnterState();
        state = newState;
        OnExitState();
    }

    protected void OnEnterState() {
        switch (state) {
            
        }
        
    }

    protected void OnExitState() {
        
    }
    
}


