
using System;
using UnityEngine;
using UnityEngine.UI;

public class TechnicManager : MonoBehaviour
{
    public Image mainTechnicImage;
    public Image secondaryTechnicImage;
    
    
    // ----- Implement Singleton
    
    public static TechnicManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // ----- Other Methods
    
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
