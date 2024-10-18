using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

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

    private EnemyDirector director;
    private int waveNumber = 0;
    private const float TimeBetweenWaves = 20f;
    private const int BaseEnemyCount = 3;
    private const int EnemyIncreasePerWave = 2;

    private List<Enemy> activeEnemies = new List<Enemy>();
    public event Action OnWaveCompleted;
    public event Action<int> OnWaveStarted;

    public void Initialize()
    {
        director = new EnemyDirector(baseEnemyPrefab);
        
        StartCoroutine(WaveSpawner());
        
    }

    private IEnumerator WaveSpawner()
    {
        while (true)
        {
            waveNumber++;
            WaveTitleUI.Instance.SetWaveTitle(waveNumber);
            WaveTitleUI.Instance.SetWaveInfos($"Début de la vague {waveNumber}", 5f);
            int enemyCount = BaseEnemyCount + (waveNumber - 1) * EnemyIncreasePerWave;
            List<EnemyType> enemyTypes = new List<EnemyType> { EnemyType.Goblin, EnemyType.Dragon };
    
            OnWaveStarted?.Invoke(waveNumber);
            yield return StartCoroutine(SpawnEnemyWave(enemyCount, enemyTypes));
    
            yield return new WaitUntil(() => activeEnemies.Count == 0);
        
            // wait for time between waves
            yield return new WaitForSeconds(TimeBetweenWaves);
        }
    }

    private IEnumerator SpawnEnemyWave(int enemyCount, List<EnemyType> enemyTypes)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            EnemyType randomType = enemyTypes[Random.Range(0, enemyTypes.Count)];
            Enemy enemy = CreateEnemy(randomType);
            enemy.IncreaseStats(1 + ((waveNumber - 1) * 0.3f));
            activeEnemies.Add(enemy);
            
            // Subscribe to enemy's death event
            enemy.OnDeath += () => RemoveEnemy(enemy);
            
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log($"Wave {waveNumber} spawned with {enemyCount} enemies");
        WaveTitleUI.Instance.SetWaveInfos($"{enemyCount} ennemis sont apparus.", 3f);
    }

    private Enemy CreateEnemy(EnemyType type)
    {
        Vector3 spawnPosition = transform.position;
        
        switch (type)
        {
            case EnemyType.Goblin:
                return director.BuildGoblin(goblinPrefab, spawnPosition);
            case EnemyType.Dragon:
                return director.BuildDragon(dragonPrefab, spawnPosition);
            default:
                Debug.LogError("Unknown enemy type");
                return null;
        }
    }

    private void RemoveEnemy(Enemy enemy)
    {
        
        activeEnemies.Remove(enemy);
        if (activeEnemies.Count == 0)
        {
            OnWaveCompleted?.Invoke();
            Debug.Log($"Wave {waveNumber} completed");
            WaveTitleUI.Instance.SetWaveInfos($"Vague {waveNumber} complétée !", 5f);
        }
        
        Destroy(enemy.gameObject);
    }
}