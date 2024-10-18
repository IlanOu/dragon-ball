using System.Collections;
using UnityEngine;

public class FinalFlash : ITechnic
{
    public override GameObject prefab { get; set; }
    public override float damagesMultiplier { get; set; }
    
    public float chargeTime = 3.0f;
    public float attackDuration = 3.0f;
    public float attackWidth = 5f;
    public float attackSpeed = 15f;
    public float cooldownTime = 15f;

    private GameObject finalFlashInstance;
    private bool isCooldown = false;
    
    public override void Attack()
    {
        if (!PlayerInfos.Instance.isAttacking && !PlayerInfos.Instance.isAttackCharging && !isCooldown)
        {
            PlayerInfos.Instance.StartCoroutine(PerformFinalFlash());
        }
        else
        {
            Debug.Log("Impossible de lancer le Final Flash pour le moment.");
        }
    }

    private IEnumerator PerformFinalFlash()
    {
        PlayerInfos.Instance.isAttackCharging = true;
        Debug.Log("Charge du Final Flash...");
        if (PlayerInfos.Instance.mainTechnic == this)
        {
            TechnicManager.Instance.mainTechnicImage.fillAmount = 0f;
        }else if (PlayerInfos.Instance.secondaryTechnic == this)
        {
            TechnicManager.Instance.secondaryTechnicImage.fillAmount = 0f;
        }
        
        
        // Effet de charge plus intense
        // TODO: Ajouter des effets visuels et sonores pour la charge

        yield return new WaitForSeconds(chargeTime);

        PlayerInfos.Instance.isAttackCharging = false;
        PlayerInfos.Instance.isAttacking = true;

        Debug.Log("Lancement du Final Flash !!!");

        Vector3 mouseDirection = GetMouseWorldPosition() - PlayerInfos.Instance.player.transform.position;
        mouseDirection.y = 0;
        Quaternion rotation = Quaternion.LookRotation(mouseDirection);

        finalFlashInstance = Instantiate(prefab, PlayerInfos.Instance.player.transform.position, rotation);
        DamageDealer damageDealer = finalFlashInstance.GetComponent<DamageDealer>();
        if (damageDealer == null)
        {
            damageDealer = finalFlashInstance.AddComponent<DamageDealer>();
        }
        if (damageDealer != null)
        {
            damageDealer.damage = Mathf.RoundToInt(PlayerInfos.Instance.strength * (1 + damagesMultiplier/10));
        }
        
        // Ajuster la taille du Final Flash
        finalFlashInstance.transform.localScale = new Vector3(attackWidth, finalFlashInstance.transform.localScale.y, finalFlashInstance.transform.localScale.z);

        float elapsedTime = 0f;
        while (elapsedTime < attackDuration)
        {
            if (finalFlashInstance != null)
            {
                finalFlashInstance.transform.Translate(Vector3.forward * attackSpeed * Time.deltaTime);
                
                // Effet de pulsation
                float scale = Mathf.PingPong(elapsedTime * 4, 0.5f) + 0.75f;
                finalFlashInstance.transform.localScale = new Vector3(attackWidth * scale, finalFlashInstance.transform.localScale.y, finalFlashInstance.transform.localScale.z);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (finalFlashInstance != null)
        {
            // Effet d'explosion à la fin
            // TODO: Ajouter un effet d'explosion
            Destroy(finalFlashInstance);
        }

        Debug.Log("Final Flash terminé.");

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
        
        Debug.Log("Final Flash en recharge...");

        
        yield return new WaitForSeconds(cooldownTime);

        isCooldown = false;
        Debug.Log("Final Flash prêt !");
        if (PlayerInfos.Instance.mainTechnic == this)
        {
            TechnicManager.Instance.mainTechnicImage.fillAmount = 1f;
        }else if (PlayerInfos.Instance.secondaryTechnic == this)
        {
            TechnicManager.Instance.secondaryTechnicImage.fillAmount = 1f;
        }
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