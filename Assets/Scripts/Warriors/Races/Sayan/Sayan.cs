using System;
using UnityEngine;

public class Sayan : Race
{
    private EvolutionStateMachine evolutionStateMachine;

    private void Start()
    {
        // Default parameters for Sayans
        
        PlayerInfos.Instance.SetMaxLife(10f);
        PlayerInfos.Instance.FullHeal();
        PlayerInfos.Instance.SetSpeed(10f);
        PlayerInfos.Instance.SetStrength(5f);
        
        evolutionStateMachine = GetComponent<EvolutionStateMachine>();
        if (evolutionStateMachine == null)
            evolutionStateMachine = gameObject.AddComponent<EvolutionStateMachine>();
        evolutionStateMachine.ChangeState(new SuperSayanI(gameObject, evolutionStateMachine));

        PlayerInfos.Instance.OnDeath.AddListener(Reset);
    }
    
    public override void Attack()
    { }

    private void Update()
    {
        evolutionStateMachine.currentState.Update();
    }

    public void Reset()
    {
        Debug.Log("Reset to Sayan");
        evolutionStateMachine.ChangeState(new SuperSayanI(gameObject, evolutionStateMachine));
        PlayerInfos.Instance.OnDeath.RemoveListener(Reset);
    }
}