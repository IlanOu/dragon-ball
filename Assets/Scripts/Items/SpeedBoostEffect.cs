using System.Collections;
using UnityEngine;

public class SpeedBoostEffect : MonoBehaviour
{
    private float originalSpeed;
    private float speedMultiplier;
    private float duration;

    public void Initialize(float multiplier, float duration)
    {
        this.speedMultiplier = multiplier;
        this.duration = duration;

        // Modifier la vitesse du joueur
        originalSpeed = PlayerInfos.Instance.speed;
        PlayerInfos.Instance.SetSpeed(originalSpeed * speedMultiplier);

        Debug.Log("Player is BOOSTED !!!");
        
        // Lance une coroutine pour réinitialiser après le délai
        StartCoroutine(RemoveEffectAfterDuration());
    }

    private IEnumerator RemoveEffectAfterDuration()
    {
        yield return new WaitForSeconds(duration);

        // Rétablir la vitesse initiale et détruire ce composant
        PlayerInfos.Instance.SetSpeed(originalSpeed);
        Destroy(this);
    }
}