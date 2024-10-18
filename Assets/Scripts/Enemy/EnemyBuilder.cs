using UnityEngine;

public class EnemyBuilder
{
    private GameObject enemyPrefab;

    public EnemyBuilder(GameObject enemyPrefab)
    {
        this.enemyPrefab = enemyPrefab;
    }

    public Enemy BuildEnemy(GameObject specificModelPrefab, string name, int health, int attack, float speed, Vector3 spawnPosition)
    {
        GameObject enemyObject = GameObject.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemy = enemyObject.AddComponent<Enemy>();
        
        enemy.SetName(name);
        enemy.SetHealth(health);
        enemy.SetAttack(attack);
        enemy.SetSpeed(speed);
        enemy.SetModel(specificModelPrefab);
        enemy.AddPathfindingSystem();

        return enemy;
    }
}