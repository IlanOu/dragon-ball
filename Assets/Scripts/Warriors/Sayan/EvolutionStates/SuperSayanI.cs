using UnityEngine;

public class SuperSayanI : EvolutionState
{

    public float maxLife = 12f;
    
    public SuperSayanI(GameObject gameObject, EvolutionStateMachine stateMachine)
        : base(gameObject, stateMachine) { }

    public override void Enter()
    {
        Statistics.Instance.SetMaxLife(maxLife);
        Debug.Log("Entering Super Sayan 1 mode");
        Statistics.Instance.SetMaxLife(maxLife);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Space pressed");
            evolutionStateMachine.ChangeState(new SuperSayanII(gameObject, evolutionStateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Super Sayan 1 mode");
    }
}