
using UnityEngine;
using UnityEngine.AI;

public class CharacterMaker : MonoBehaviour
{
    public GameObject GenerateCharacter(CharacterDatabase.CharacterInfo characterInfo)
    {
        GameObject instantiateChar = Instantiate(characterInfo.prefabCharacter);
        instantiateChar.name = characterInfo.name;

        AgentMovement agentMovement = instantiateChar.AddComponent<AgentMovement>();
        NavMeshAgent navMeshAgent = instantiateChar.AddComponent<NavMeshAgent>();
        
        navMeshAgent.speed = PlayerInfos.Instance.speed;
        navMeshAgent.angularSpeed = 1000f;
        navMeshAgent.acceleration = 100f;
        
        agentMovement.agent = navMeshAgent;
        
        return instantiateChar;
    }
}