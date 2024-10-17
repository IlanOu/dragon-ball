using System.Collections;
using UnityEngine;

public class DeathBeam : ITechnic
{
    public override GameObject prefab { get; set; }

    private const float CHARGE_TIME = 0.5f;
    private const float BEAM_DURATION = 3f;
    private const float COOLDOWN_TIME = 7f;
    private const float BEAM_SPEED = 40f;

    private bool isCharging = false;
    private bool isFiring = false;
    private bool isOnCooldown = false;

    public override void Attack()
    {
        if (!isCharging && !isFiring && !isOnCooldown)
        {
            PlayerInfos.Instance.StartCoroutine(PerformDeathBeam());
        }
        else
        {
            Debug.Log("Death Beam n'est pas prêt !");
        }
    }

    private IEnumerator PerformDeathBeam()
    {
        isCharging = true;
        Debug.Log("Charge du Death Beam...");
        yield return new WaitForSeconds(CHARGE_TIME);
        isCharging = false;

        isFiring = true;
        Debug.Log("Lancement du Death Beam !");

        Vector3 direction = (GetMouseWorldPosition() - PlayerInfos.Instance.player.transform.position).normalized;
        GameObject beam = Object.Instantiate(prefab, PlayerInfos.Instance.player.transform.position, Quaternion.LookRotation(direction));

        float elapsedTime = 0f;
        while (elapsedTime < BEAM_DURATION)
        {
            beam.transform.position += direction * BEAM_SPEED * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Object.Destroy(beam);
        isFiring = false;
        Debug.Log("Death Beam terminé.");

        StartCooldown();
    }

    private void StartCooldown()
    {
        PlayerInfos.Instance.StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        isOnCooldown = true;
        Debug.Log("Death Beam en recharge...");
        yield return new WaitForSeconds(COOLDOWN_TIME);
        isOnCooldown = false;
        Debug.Log("Death Beam prêt !");
    }

    private Vector3 GetMouseWorldPosition()
    {
        Plane plane = new Plane(Vector3.up, PlayerInfos.Instance.player.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return PlayerInfos.Instance.player.transform.position;
    }
}