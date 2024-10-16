using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class CharacterInfo
{
    [FormerlySerializedAs("character")] public RaceType race;
    public Sprite buttonImage;
}