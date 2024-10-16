using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EvolutionState
{
    
    protected GameObject gameObject;
    protected EvolutionStateMachine evolutionStateMachine;

    
    public EvolutionState(GameObject gameObject, EvolutionStateMachine evolutionStateMachine)
    {
        this.gameObject = gameObject;
        this.evolutionStateMachine = evolutionStateMachine;
    }

    
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}

