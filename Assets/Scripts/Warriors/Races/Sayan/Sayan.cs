using System;
using UnityEngine;

public class Sayan : Race
{
    private EvolutionStateMachine evolutionStateMachine;

    private void Start()
    {
        // Default parameters for Sayans
        
        PlayerInfos.Instance.FullHeal();
        
        evolutionStateMachine = new EvolutionStateMachine();
        evolutionStateMachine.ChangeState(new SuperSayanI(gameObject, evolutionStateMachine));
    }
    
    public override void Attack()
    {
        Debug.Log(" attaque avec un Kamehameha !");
    }

    private void Update()
    {
        evolutionStateMachine.currentState.Update();
    }
}