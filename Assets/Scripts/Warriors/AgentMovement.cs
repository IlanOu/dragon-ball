using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 target;
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
                agent.SetDestination(target);
            }
        }
        
        if (PlayerInfos.Instance.isAttackCharging)
        {
            agent.SetDestination(PlayerInfos.Instance.player.transform.position);
        }
        else
        {
            if (agent.destination != target)
            {
                agent.SetDestination(target);
            }
        }
    }
}