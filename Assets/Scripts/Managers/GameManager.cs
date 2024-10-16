using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject characterPrefab;
    
    private void Start()
    {
        
    }
    
    public void StartGame()
    {
        GameObject sayanObject = Instantiate(characterPrefab);
        Character sayan = CharacterFactory.CreateCharacter(CharacterType.Sayan, sayanObject);
    }
}