
using UnityEngine;
using UnityEngine.UIElements;

public class DeathUI : MonoBehaviour
{
    public GameObject deathUI;

    private void Start()
    {
        Hide();
    }    
    public void Show()
    {
        deathUI.SetActive(true);
    }
    
    public void Hide()
    {
        deathUI.SetActive(false);
    }
}
