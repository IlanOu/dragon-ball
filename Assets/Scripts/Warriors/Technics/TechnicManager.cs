
using System;
using UnityEngine;

public class TechnicManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInfos.Instance.mainTechnic.Attack();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerInfos.Instance.secondaryTechnic.Attack();
        }
    }
}
