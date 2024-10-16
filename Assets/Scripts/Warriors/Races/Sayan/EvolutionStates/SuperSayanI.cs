using UnityEngine;

public class SuperSayanI : EvolutionState
{
    public float maxLife = 10f;
    
    public SuperSayanI(GameObject gameObject, EvolutionStateMachine stateMachine)
        : base(gameObject, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Sayan mode");
        PlayerInfos.Instance.SetMaxLife(maxLife);
    }

    public override void Update()
    {
        Debug.Log("Super Sayan I Update");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            evolutionStateMachine.ChangeState(new SuperSayanII(gameObject, evolutionStateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Sayan mode");
    }
}