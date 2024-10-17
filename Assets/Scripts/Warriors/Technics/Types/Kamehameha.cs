using System.Collections;
using UnityEngine;

public class Kamehameha : ITechnic
{
    public override GameObject prefab { get; set; }
    public override float damagesMultiplier { get; set; }
    
    public float chargeTime = 2.0f;
    public float attackDuration = 5.0f;
    public float attackSpeed = 10f;
    public float cooldownTime = 10f;

    private GameObject kamehamehaInstance;
    private bool isCooldown = false;
    
    public override void Attack()
    {
        if (!PlayerInfos.Instance.isAttacking && !PlayerInfos.Instance.isAttackCharging && !isCooldown)
        {
            PlayerInfos.Instance.StartCoroutine(PerformKamehameha());
        }
        else
        {
            Debug.Log("Impossible de lancer le Kamehameha pour le moment.");
        }
    }

    private IEnumerator PerformKamehameha()
    {
        PlayerInfos.Instance.isAttackCharging = true;
        
        Debug.Log("Charge du Kamehameha...");

        yield return new WaitForSeconds(chargeTime);

        PlayerInfos.Instance.isAttackCharging = false;
        PlayerInfos.Instance.isAttacking = true;

        Debug.Log("Lancement du Kamehameha !!!");

        // Calculer la direction vers la souris
        Vector3 mouseDirection = GetMouseWorldPosition() - PlayerInfos.Instance.player.transform.position;
        mouseDirection.y = 0; // Ignorer la différence de hauteur pour une vue isométrique
        Quaternion rotation = Quaternion.LookRotation(mouseDirection);

        // Instancier le Kamehameha avec la rotation calculée
        kamehamehaInstance = Instantiate(prefab, PlayerInfos.Instance.player.transform.position, rotation);
        DamageDealer damageDealer = kamehamehaInstance.GetComponent<DamageDealer>();
        if (damageDealer == null)
        {
            damageDealer = kamehamehaInstance.AddComponent<DamageDealer>();
        }
        if (damageDealer != null)
        {
            damageDealer.damage = Mathf.RoundToInt(PlayerInfos.Instance.strength * (1 + damagesMultiplier/10));
        }
        
        float elapsedTime = 0f;
        while (elapsedTime < attackDuration)
        {
            if (kamehamehaInstance != null)
            {
                kamehamehaInstance.transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (kamehamehaInstance != null)
        {
            Destroy(kamehamehaInstance);
        }

        Debug.Log("Kamehameha terminé.");

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
        Debug.Log("Kamehameha en recharge...");

        yield return new WaitForSeconds(cooldownTime);

        isCooldown = false;
        Debug.Log("Kamehameha prêt !");
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Créer un plan à la hauteur du joueur
        Plane plane = new Plane(Vector3.up, PlayerInfos.Instance.player.transform.position);

        // Lancer un rayon depuis la caméra vers la position de la souris
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        // Si le rayon ne touche pas le plan, retourner la position du joueur
        return PlayerInfos.Instance.player.transform.position;
    }
}