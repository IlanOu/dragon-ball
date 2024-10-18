using UnityEngine;

public class EnemyDirector
{
    private GameObject basePrefab;

    public EnemyDirector(GameObject basePrefab)
    {
        this.basePrefab = basePrefab;
    }

    public Enemy BuildGoblin(GameObject goblinPrefab, Vector3 spawnPosition)
    {
        EnemyBuilder builder = new EnemyBuilder(basePrefab);
        return builder.BuildEnemy(goblinPrefab, "Goblin", 12, 1, 3.5f, spawnPosition);
    }

    public Enemy BuildDragon(GameObject dragonPrefab, Vector3 spawnPosition)
    {
        EnemyBuilder builder = new EnemyBuilder(basePrefab);
        return builder.BuildEnemy(dragonPrefab, "Dragon", 20, 3, 5.0f, spawnPosition);
    }
}