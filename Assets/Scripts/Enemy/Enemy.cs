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

    public event Action OnDeath;
    
    public float attackRange = 2f; // Distance à laquelle l'ennemi peut attaquer
    public float attackCooldown = 1f; // Temps entre chaque attaque
    private float lastAttackTime;
    
    // ----- Builder methods
    
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
        if (agent)
        {
            agent.speed = speed;
        }
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
    
    
    // ----- Other methods

    public void IncreaseStats(float multiplier)
    {
        health = Mathf.RoundToInt(health * multiplier);
        attack = Mathf.RoundToInt(attack * multiplier);
        speed *= multiplier;
    }
    
    // ----- Events

    public void Kill()
    {
        OnDeath?.Invoke();
    }
    
    public void TakeDamage(int damage)
    {
        Debug.Log("" + enemyName + " took " + damage + " damage.");
        health -= damage;
        
        if (health <= 0)
        {
            Kill();
        }
    }
    
    
    void Update()
    {
        if (usePathfinding)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, PlayerInfos.Instance.player.transform.position);

            if (distanceToPlayer <= attackRange)
            {
                // L'ennemi est assez proche pour attaquer
                StopMoving();
                AttackPlayer();
            }
            else
            {
                // L'ennemi doit se rapprocher du joueur
                ResumeMoving();
                SetPathfindingTarget(PlayerInfos.Instance.player.transform);
            }
        }

        if (health <= 0)
        {
            Kill();
        }
    }

    private void StopMoving()
    {
        if (agent != null)
        {
            agent.isStopped = true;
        }
    }

    private void ResumeMoving()
    {
        if (agent != null)
        {
            agent.isStopped = false;
        }
    }

    private void AttackPlayer()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PlayerInfos.Instance.TakeDamage(attack);
            
            lastAttackTime = Time.time;
        }
    }

    public void SetPathfindingTarget(Transform target)
    {
        if (agent != null)
        {
            agent.SetDestination(target.position);
        }
    }
}