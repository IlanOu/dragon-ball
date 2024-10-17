using System.Collections;
using UnityEngine;

public class GalickGun : ITechnic
{
    public override GameObject prefab { get; set; }
    public override float damagesMultiplier { get; set; }
    
    public float chargeTime = 1.5f; // Temps de charge plus court
    public float attackDuration = 2.0f; // Durée courte mais intense
    public float attackSpeed = 20f; // Vitesse très rapide
    public float cooldownTime = 8f; // Temps de recharge moyen
    public int burstCount = 3; // Nombre de tirs dans une rafale
    public float burstDelay = 0.2f; // Délai entre chaque tir de la rafale

    private bool isCooldown = false;
    
    public override void Attack()
    {
        if (!PlayerInfos.Instance.isAttacking && !PlayerInfos.Instance.isAttackCharging && !isCooldown)
        {
            PlayerInfos.Instance.StartCoroutine(PerformGalickGun());
        }
        else
        {
            Debug.Log("Impossible de lancer le Galick Gun pour le moment.");
        }
    }

    private IEnumerator PerformGalickGun()
    {
        PlayerInfos.Instance.isAttackCharging = true;
        Debug.Log("Charge du Galick Gun...");

        // TODO: Ajouter des effets visuels et sonores pour la charge
        yield return new WaitForSeconds(chargeTime);

        PlayerInfos.Instance.isAttackCharging = false;
        PlayerInfos.Instance.isAttacking = true;

        Debug.Log("Lancement du Galick Gun !!!");

        Vector3 mouseDirection = GetMouseWorldPosition() - PlayerInfos.Instance.player.transform.position;
        mouseDirection.y = 0;
        Quaternion rotation = Quaternion.LookRotation(mouseDirection);

        for (int i = 0; i < burstCount; i++)
        {
            GameObject galickGunInstance = Instantiate(prefab, PlayerInfos.Instance.player.transform.position, rotation);
            DamageDealer damageDealer = galickGunInstance.GetComponent<DamageDealer>();
            if (damageDealer == null)
            {
                damageDealer = galickGunInstance.AddComponent<DamageDealer>();
            }
            if (damageDealer != null)
            {
                damageDealer.damage = Mathf.RoundToInt(PlayerInfos.Instance.strength * damagesMultiplier);
            }
            
            // Ajuster la taille du Galick Gun (plus petit que le Kamehameha)
            galickGunInstance.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

            PlayerInfos.Instance.StartCoroutine(MoveGalickGun(galickGunInstance));

            if (i < burstCount - 1)
            {
                yield return new WaitForSeconds(burstDelay);
            }
        }

        yield return new WaitForSeconds(attackDuration);

        Debug.Log("Galick Gun terminé.");

        PlayerInfos.Instance.isAttacking = false;
        StartCooldown();
    }

    private IEnumerator MoveGalickGun(GameObject galickGunInstance)
    {
        float elapsedTime = 0f;
        while (elapsedTime < attackDuration && galickGunInstance != null)
        {
            galickGunInstance.transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
            
            // Effet de traînée
            // TODO: Ajouter un effet de traînée visuelle

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (galickGunInstance != null)
        {
            // Effet d'impact
            // TODO: Ajouter un effet d'impact
            Destroy(galickGunInstance);
        }
    }

    private void StartCooldown()
    {
        PlayerInfos.Instance.StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        Debug.Log("Galick Gun en recharge...");

        yield return new WaitForSeconds(cooldownTime);

        isCooldown = false;
        Debug.Log("Galick Gun prêt !");
    }

    private Vector3 GetMouseWorldPosition()
    {
        Plane plane = new Plane(Vector3.up, PlayerInfos.Instance.player.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        return PlayerInfos.Instance.player.transform.position;
    }
}