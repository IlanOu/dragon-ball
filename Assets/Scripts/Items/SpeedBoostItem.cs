using UnityEngine;

public class SpeedBoostItem : MonoBehaviour, IItemEffect
{
    public float speedMultiplier = 2f;
    public float duration = 5f;

    public void ApplyEffect()
    {
        SpeedBoostEffect boost = PlayerInfos.Instance.player.AddComponent<SpeedBoostEffect>();
        boost.Initialize(speedMultiplier, duration);
    }
}