using UnityEngine;

public class SuperSayanIII : EvolutionState
{
    public float maxLife = 15f;
    
    public SuperSayanIII(GameObject gameObject, EvolutionStateMachine stateMachine)
        : base(gameObject, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Super Sayan 3 mode");
        PlayerInfos.Instance.SetMaxLife(maxLife);
        PlayerInfos.Instance.SetSpeed(12f);
        PlayerInfos.Instance.SetStrength(14f);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Space pressed");
            evolutionStateMachine.ChangeState(new SuperSayanGod(gameObject, evolutionStateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Super Sayan 3 mode");
    }
}