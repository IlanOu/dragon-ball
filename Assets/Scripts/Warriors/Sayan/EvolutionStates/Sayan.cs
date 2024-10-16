using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Sayan: EvolutionState
{
    public float maxLife = 10f;
    
    public Sayan(GameObject gameObject, EvolutionStateMachine stateMachine)
        : base(gameObject, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Sayan mode");
        Statistics.Instance.SetMaxLife(maxLife);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            evolutionStateMachine.ChangeState(new SuperSayanI(gameObject, evolutionStateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Sayan mode");
    }
}