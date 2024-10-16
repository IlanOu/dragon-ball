using UnityEngine;

public class Sayan : Character
{
    private EvolutionStateMachine evolutionStateMachine;

    private void Start()
    {
        // Default parameters for Sayans
        characterName = "Sayan";

        evolutionStateMachine = new EvolutionStateMachine();
        evolutionStateMachine.ChangeState(new SuperSayanI(gameObject, evolutionStateMachine));
    }
    
    public override void Attack()
    {
        Debug.Log(characterName + " attaque avec un Kamehameha !");
    }
}