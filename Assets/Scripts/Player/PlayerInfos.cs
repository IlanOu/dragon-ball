
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PlayerInfos: MonoBehaviour
{
    // ----- Implement Singleton
    
    public static PlayerInfos Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // ----- Properties
    
    public float maxLife = 10.0f;
    public int globalLife = 3;
    public float life = 0.0f;
    public float strength = 0.0f;
    public float speed = 10f;
    public bool isAlive = true;
    public GameObject player;
    public NavMeshAgent playerAgent;
    
    public ITechnic mainTechnic;
    public ITechnic secondaryTechnic;
    
    public bool isAttacking = false; 
    public bool isAttackCharging = false; 
    
    public UnityEvent OnDeath;
    
    
    // ----- Methods

    public void Kill()
    {
        life = 0;
        isAlive = false;
        
        globalLife -= 1;
        OnDeath?.Invoke();
    }
    
    public void TakeDamage(float damage)
    {
        life -= damage;
        
        if (life <= 0 && isAlive)
        {
            Kill();
        }
    }
    
    public void Heal(float heal)
    {
        if (life + heal < maxLife)
        {
            life += heal;
        }
        else
        {
            life = maxLife;
        }
    }
    
    public void FullHeal()
    {
        life = maxLife;
    }

    public void SetLife(float amount)
    {
        if (amount < maxLife)
        {
            life = amount;
        }
        else
        {
            life = maxLife;
        }
    }
    
    public void SetMaxLife(float amount)
    {
        maxLife = amount;
    }
    
    public void SetSpeed(float amount)
    {
        speed = amount;
        playerAgent.speed = speed;
    }
    
    public void SetStrength(float amount)
    {
        strength = amount;
    }
    
    public PlayerMemento SaveState()
    {
        Debug.Log("Save all player infos : " + player.transform.position);
        return new PlayerMemento(player.transform.position, player.transform.rotation, player.transform.localScale, maxLife, life, isAlive);
    }

    // Restaurer l'état du joueur depuis un Memento
    public void RestoreState(PlayerMemento memento)
    {
        player.transform.position = memento.Position;
        player.transform.rotation = memento.Rotation;
        player.transform.localScale = memento.Scale;
        life = memento.Life;
        maxLife = memento.MaxLife;
        isAlive = memento.IsAlive;
        player.GetComponent<AgentMovement>().target = player.transform.position;

        Heal(maxLife);
    }
}