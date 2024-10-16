using UnityEngine;

public class RaceFactory
{
    public Race CreateCharacter(RaceType race, GameObject characterPrefab)
    {
        switch (race)
        {
            case RaceType.Sayan:
                return characterPrefab.AddComponent<Sayan>();
            case RaceType.Namekian:
                return characterPrefab.AddComponent<Namekian>();
            case RaceType.Android:
                return characterPrefab.AddComponent<Android>();
            default:
                Debug.LogError("Unknown character type: " + race);
                return null;
        }
    }
}