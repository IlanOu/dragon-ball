using UnityEngine;

public class Namekian : Race
{

    private void Start()
    {
        PlayerInfos.Instance.SetMaxLife(13f);
        PlayerInfos.Instance.FullHeal();
        PlayerInfos.Instance.SetSpeed(9f);
        PlayerInfos.Instance.SetStrength(6f);
    }
    
    public override void Attack()
    {
        Debug.Log(" attaque avec un Kamehameha !");
    }
}