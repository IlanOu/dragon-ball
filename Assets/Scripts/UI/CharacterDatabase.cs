using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "Game/Character Database")]
public class CharacterDatabase : ScriptableObject
{
    [System.Serializable]
    public class CharacterInfo
    {
        public string name;
        public CharacterType type;
        public Sprite buttonImage;
    }

    public List<CharacterInfo> characters;
}