
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMaker : MonoBehaviour
{
    private GameObject instantiateChar;
    
    public GameObject GenerateCharacter(CharacterDatabase.CharacterInfo characterInfo)
    {
        instantiateChar = Instantiate(characterInfo.prefabCharacter);
        instantiateChar.name = characterInfo.name;

        PlayerInfos.Instance.player = instantiateChar;
        
        AgentMovement agentMovement = instantiateChar.AddComponent<AgentMovement>();
        NavMeshAgent navMeshAgent = instantiateChar.AddComponent<NavMeshAgent>();
        
        
        PlayerInfos.Instance.playerAgent = navMeshAgent;    
        
        navMeshAgent.speed = PlayerInfos.Instance.speed;
        navMeshAgent.angularSpeed = 1000f;
        navMeshAgent.acceleration = 100f;
        
        agentMovement.agent = navMeshAgent;
        
        ITechnic mainTechnic = SetTechnicByType(characterInfo.mainTechnic);
        ITechnic secondaryTechnic = SetTechnicByType(characterInfo.secondaryTechnic);
        
        PlayerInfos.Instance.mainTechnic = mainTechnic;
        PlayerInfos.Instance.secondaryTechnic = secondaryTechnic;
        
        return instantiateChar;
    }

    public ITechnic SetTechnicByType(TechnicType type)
    {
        ITechnic technic;
        switch (type)
        {
            case TechnicType.deathbeam:
                technic = instantiateChar.AddComponent<DeathBeam>();
                return technic;
            case TechnicType.kamehameha:
                technic = instantiateChar.AddComponent<Kamehameha>();
                return technic;
            case TechnicType.galickgun:
                technic = instantiateChar.AddComponent<GalickGun>();
                return technic;
            case TechnicType.finalflash:
                technic = instantiateChar.AddComponent<FinalFlash>();
                return technic;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}