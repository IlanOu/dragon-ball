using UnityEngine;

public class PlayerMemento
{
    public Vector3 Position { get; }
    public Quaternion Rotation { get; }
    public Vector3 Scale { get; }
    public float Life { get; }
    public float MaxLife { get; }
    public bool IsAlive { get; }

    public PlayerMemento(Vector3 position, Quaternion rotation, Vector3 scale, float maxLife, float life, bool isAlive)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
        Life = life;
        MaxLife = maxLife;
        IsAlive = isAlive;
    }
}