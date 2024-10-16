using UnityEngine;

public class CharacterFactory
{
    public static Character CreateCharacter(CharacterType characterType, GameObject characterGameObject)
    {
        switch (characterType)
        {
            case CharacterType.Sayan:
                return characterGameObject.AddComponent<Sayan>();
            case CharacterType.Namekian:
                return characterGameObject.AddComponent<Namekian>();
            case CharacterType.Android:
                return characterGameObject.AddComponent<Android>();
            default:
                Debug.LogError("Unknown character type: " + characterType);
                return null;
        }
    }
}