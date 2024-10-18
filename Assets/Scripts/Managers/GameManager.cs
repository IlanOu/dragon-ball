using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // ----- Implement Singleton

    public static GameManager Instance;

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
    
    // ----- 

    
    // Called when player is ready
    public void Initialize()
    {
        SavePlayerState();
    }

    // J'ai mis une mile même s'il n'y aura jamais plus d'1 sauvegarde
    private Stack<PlayerMemento> savedStates = new Stack<PlayerMemento>();
    
    // Sauvegarder l'état actuel du joueur
    public void SavePlayerState()
    {
        savedStates.Push(PlayerInfos.Instance.SaveState());
    }

    // Restaurer l'état du joueur à la dernière sauvegarde
    public void RestorePlayerState()
    {
        if (savedStates.Count > 0)
        {
            PlayerMemento memento = savedStates.Pop();
            PlayerInfos.Instance.RestoreState(memento);
            SavePlayerState();
        }
        else
        {
            Debug.Log("Aucune sauvegarde trouvée.");
        }
    }
    

}