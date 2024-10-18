using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image bar;
    

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = PlayerInfos.Instance.life/PlayerInfos.Instance.maxLife;
    }
}
