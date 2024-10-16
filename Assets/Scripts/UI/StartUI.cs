using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;
    public CharacterDatabase characterDatabase;
    
    private Dictionary<RaceType, CharacterInfo> characterInfoDictionary;
    
    RaceFactory _raceFactory = new RaceFactory();
    public CharacterMaker characterMaker;
    

    void Start()
    {
        CreateButtons();
    }

    void CreateButtons()
    {
        foreach (var character in characterDatabase.characters)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonContainer);
            Button button = buttonObj.GetComponent<Button>();
            
            // Configurer l'image du bouton
            RawImage buttonImage = button.GetComponent<RawImage>();
            if (buttonImage != null)
            {
                buttonImage.texture = character.buttonImage.texture;
            }

            // Configurer le texte du bouton
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = character.name;
            }

            // Configurer l'action du bouton
            button.onClick.AddListener(() => OnCharacterSelected(character));
        }
    }

    void OnCharacterSelected(CharacterDatabase.CharacterInfo selectedCharacter)
    {
        // PlayerInfos.Instance.SetCharacter(selectedCharacter);
        Debug.Log("Character sélectionnée : " + selectedCharacter);
        
        _raceFactory.CreateCharacter(selectedCharacter.type, characterMaker.GenerateCharacter(selectedCharacter));
        
        CloseUI();
        
    }

    void CloseUI()
    {
        gameObject.SetActive(false);
    }
}