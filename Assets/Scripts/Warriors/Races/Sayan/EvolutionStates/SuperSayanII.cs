using UnityEngine;

public class SuperSayanII : EvolutionState
{

    public float maxLife = 12f;
    
    public SuperSayanII(GameObject gameObject, EvolutionStateMachine stateMachine)
        : base(gameObject, stateMachine) { }

    public override void Enter()
    {
        PlayerInfos.Instance.SetMaxLife(maxLife);
        Debug.Log("Entering Super Sayan 2 mode");
        PlayerInfos.Instance.SetMaxLife(maxLife);
        PlayerInfos.Instance.SetSpeed(12f);
        PlayerInfos.Instance.SetStrength(12f);
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