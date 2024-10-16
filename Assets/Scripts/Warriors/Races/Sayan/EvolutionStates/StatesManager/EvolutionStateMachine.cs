using UnityEngine;

public class EvolutionStateMachine : MonoBehaviour
{
    public EvolutionState currentState;

    public void ChangeState(EvolutionState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }
}