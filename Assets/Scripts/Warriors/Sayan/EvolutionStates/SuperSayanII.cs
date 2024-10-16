using UnityEngine;

public class SuperSayanII : EvolutionState
{
    public float maxLife = 15f;
    
    public SuperSayanII(GameObject gameObject, EvolutionStateMachine stateMachine)
        : base(gameObject, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Super Sayan 2 mode");
        Statistics.Instance.SetMaxLife(maxLife);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Space pressed");
            evolutionStateMachine.ChangeState(new SuperSayanIII(gameObject, evolutionStateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Super Sayan 2 mode");
    }
}