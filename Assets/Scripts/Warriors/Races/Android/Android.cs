using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android : Race
{
    private void Start()
    {
        // characterName = "Android";
    }

    public override void Attack()
    {
        Debug.Log(" attaque avec un Kamehameha !");
    }
}
