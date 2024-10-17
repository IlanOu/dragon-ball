using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private string enemyName;
    private int health;
    private int attack;
    private float speed;
    private GameObject model;
    private bool usePathfinding = false;

    private NavMeshAgent agent;
    
    public void SetName(string name)
    {
        enemyName = name;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void SetAttack(int attack)
    {
        this.attack = attack;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetModel(GameObject modelPrefab)
    {
        if (model != null)
        {
            Destroy(model);
        }

        model = Instantiate(modelPrefab, transform);
        model.transform.localPosition = Vector3.zero;
        transform.localPosition = new Vector3(0f, 2f, 0f);
    }

    public void AddPathfindingSystem()
    {
        agent = this.AddComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.acceleration = 100f;
        agent.angularSpeed = 1000f;
        agent.height = 1f;
        agent.baseOffset = 0.5f;
        usePathfinding = true;
    }
    
    void Update()
    {
        if (usePathfinding)
        {
            SetPathfindingTarget(PlayerInfos.Instance.player.transform);   
        }
    }

    public void SetPathfindingTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }

    public void DisplayEnemyInfo()
    {
        Debug.Log($"Enemy: {enemyName}, Health: {health}, Attack: {attack}, Speed: {speed}");
    }
}