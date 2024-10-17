
using System;
using UnityEngine;
using UnityEngine.AI;

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
    public float life = 0.0f;
    public float strength = 0.0f;
    public float speed = 10f;
    public bool isAlive = true;
    public GameObject player;
    public NavMeshAgent playerAgent;
    
    // ----- Methods

    public void Kill()
    {
        life = 0;
        isAlive = false;
    }
    
    public void TakeDamage(float damage)
    {
        life -= damage;
        
        if (life <= 0)
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
}