using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatsManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI lifeText;


    private void Update()
    {
        lifeText.text = "Life: " + Statistics.Instance.life.ToString() + "/" + Statistics.Instance.maxLife.ToString();
    }
}
