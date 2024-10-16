
using UnityEngine;

public class CharacterMaker : MonoBehaviour
{
    public GameObject GenerateCharacter(CharacterDatabase.CharacterInfo characterInfo)
    {
        GameObject instantiateChar = Instantiate(characterInfo.prefabCharacter);
        instantiateChar.name = characterInfo.name;
        
        return instantiateChar;
    }
}