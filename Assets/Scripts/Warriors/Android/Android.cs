using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android : Character
{
    private void Start()
    {
        characterName = "Android";
    }

    public override void Attack()
    {
        Debug.Log(characterName + " attaque avec un Kamehameha !");
    }
}
