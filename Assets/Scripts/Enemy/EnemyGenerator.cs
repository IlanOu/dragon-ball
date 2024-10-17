using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    
    // ----- Implement Singleton

    public static EnemyGenerator Instance;

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
    
    // -----
    
    [SerializeField] private GameObject baseEnemyPrefab;
    [SerializeField] private GameObject goblinPrefab;
    [SerializeField] private GameObject dragonPrefab;
    
    public void GenerateEnemies()
    {
        EnemyDirector director = new EnemyDirector(baseEnemyPrefab);
        
        // Enemy goblin = director.BuildGoblin(goblinPrefab);
        // goblin.DisplayEnemyInfo();

        Enemy dragon = director.BuildDragon(dragonPrefab);
        dragon.DisplayEnemyInfo();
    }
}
