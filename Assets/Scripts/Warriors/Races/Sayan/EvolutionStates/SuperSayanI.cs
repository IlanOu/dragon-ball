using UnityEngine;

public class SuperSayanI : EvolutionState
{
    public float maxLife = 10f;
    
    public SuperSayanI(GameObject gameObject, EvolutionStateMachine stateMachine)
        : base(gameObject, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Super Sayan mode");
        PlayerInfos.Instance.SetMaxLife(maxLife);
        PlayerInfos.Instance.SetSpeed(12f);
        PlayerInfos.Instance.SetStrength(10f);
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
        Debug.Log("Exiting Super Sayan mode");
    }
}