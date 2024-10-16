using UnityEngine;

public class SuperSayanGod : EvolutionState
{
    public float maxLife = 20f;
    
    public SuperSayanGod(GameObject gameObject, EvolutionStateMachine stateMachine)
        : base(gameObject, stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Super Sayan 3 mode");
        PlayerInfos.Instance.SetMaxLife(maxLife);
    }

    public override void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //     // Exemple : Si on appuie sur espace, on change d'état
        //     EvolutionStateMachine.ChangeState(new SuperSayanIII(gameObject, EvolutionStateMachine));
        // }
        
        Debug.Log("Can't evolve more");
    }

    public override void Exit()
    {
        Debug.Log("Exiting Super Sayan 3 mode");
    }
}