using System.Collections;
using UnityEngine;

public class DeathBeam : ITechnic
{
    public override GameObject prefab { get; set; }

    public float chargeTime = 0.5f;
    public float attackDuration = 3f;
    public float attackSpeed = 40f;
    public float cooldownTime = 7f;

    private GameObject beamInstance;
    private bool isCooldown = false;

    public override void Attack()
    {
        if (!PlayerInfos.Instance.isAttacking && !PlayerInfos.Instance.isAttackCharging && !isCooldown)
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
        PlayerInfos.Instance.isAttackCharging = true;
        
        Debug.Log("Charge du Death Beam...");
        yield return new WaitForSeconds(chargeTime);

        PlayerInfos.Instance.isAttackCharging = false;
        PlayerInfos.Instance.isAttacking = true;

        Debug.Log("Lancement du Death Beam !");

        Vector3 mouseDirection = GetMouseWorldPosition() - PlayerInfos.Instance.player.transform.position;
        mouseDirection.y = 0; // Ignorer la différence de hauteur pour une vue isométrique
        Quaternion rotation = Quaternion.LookRotation(mouseDirection);

        beamInstance = Instantiate(prefab, PlayerInfos.Instance.player.transform.position, rotation);
        DamageDealer damageDealer = beamInstance.GetComponent<DamageDealer>();
        if (damageDealer == null)
        {
            damageDealer = beamInstance.AddComponent<DamageDealer>();
        }
        if (damageDealer != null)
        {
            damageDealer.damage = 50;
        }

        float elapsedTime = 0f;
        while (elapsedTime < attackDuration)
        {
            if (beamInstance != null)
            {
                beamInstance.transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (beamInstance != null)
        {
            Destroy(beamInstance);
        }

        Debug.Log("Death Beam terminé.");

        PlayerInfos.Instance.isAttacking = false;
        StartCooldown();
    }

    private void StartCooldown()
    {
        PlayerInfos.Instance.StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        Debug.Log("Death Beam en recharge...");
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
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