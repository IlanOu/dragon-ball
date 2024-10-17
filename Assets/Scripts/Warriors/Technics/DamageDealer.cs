using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 10;
    private HashSet<Enemy> ennemisEnCollision = new HashSet<Enemy>();

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy != null && !ennemisEnCollision.Contains(enemy))
        {
            enemy.TakeDamage(damage);
            ennemisEnCollision.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            ennemisEnCollision.Remove(enemy);
        }
    }
}