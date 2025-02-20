
using TMPro;
using UnityEngine;
// using UnityEngine.UIElements;
using UnityEngine.UI;
public class DeathUI : MonoBehaviour
{
    public GameObject deathUI;
    
    public GameObject respawnButton;
    public GameObject mainMenuButton;
    public StartUI startUI;
    
    private Button respawnBTN;
    private Button mainMenuBTN;

    private void Start()
    {
        respawnBTN = respawnButton.GetComponent<Button>();
        mainMenuBTN = mainMenuButton.GetComponent<Button>();
        
        mainMenuBTN.onClick.AddListener(GoToMainMenu);
        Hide();
    }    
    public void Show()
    {
        if (PlayerInfos.Instance.globalLife <= 0)
        {
            respawnBTN.interactable = false;
        }
        
        deathUI.SetActive(true);
    }
    
    public void Hide()
    {
        deathUI.SetActive(false);
    }

    public void GoToMainMenu()
    {
        PlayerInfos.Instance.Reset();
    }
}
