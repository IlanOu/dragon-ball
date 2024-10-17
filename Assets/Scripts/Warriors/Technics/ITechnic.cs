using UnityEngine;

public abstract class ITechnic : MonoBehaviour
{
    
    public abstract float damagesMultiplier { get; set; }
    public abstract GameObject prefab { get; set; }
    
    public abstract void Attack();
}