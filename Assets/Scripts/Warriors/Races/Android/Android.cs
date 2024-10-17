using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android : Race
{
    private void Start()
    {
        PlayerInfos.Instance.SetMaxLife(14f);
        PlayerInfos.Instance.FullHeal();
        PlayerInfos.Instance.SetSpeed(4f);
        PlayerInfos.Instance.SetStrength(6f);

        // PlayerInfos.Instance.SetMainTechnic();
    }

    public override void Attack()
    {
        Debug.Log(" attaque avec un Kamehameha !");
    }
}
