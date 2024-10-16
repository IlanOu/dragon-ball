using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private EvolutionStateMachine stateMachine;
    
    private void Start()
    {
        Statistics.Instance.FullHeal();
        stateMachine.ChangeState(new Sayan(gameObject, stateMachine));
    }
}