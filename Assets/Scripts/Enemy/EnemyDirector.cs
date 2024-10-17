using UnityEngine;

public class EnemyDirector
{
    private GameObject basePrefab;

    public EnemyDirector(GameObject basePrefab)
    {
        this.basePrefab = basePrefab;
    }

    public Enemy BuildGoblin(GameObject goblinPrefab)
    {
        EnemyBuilder builder = new EnemyBuilder(basePrefab);
        return builder.BuildEnemy(goblinPrefab, "Goblin", 10, 1, 3.5f);
    }

    public Enemy BuildDragon(GameObject dragonPrefab)
    {
        EnemyBuilder builder = new EnemyBuilder(basePrefab);
        return builder.BuildEnemy(dragonPrefab, "Dragon", 20, 3, 5.0f);
    }
}