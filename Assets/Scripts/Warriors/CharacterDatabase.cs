using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "Game/Character Database")]
public class CharacterDatabase : ScriptableObject
{
    [System.Serializable]
    public class CharacterInfo
    {
        public string name;
        public RaceType type;
        public Sprite buttonImage;
        public GameObject prefabCharacter;

        public TechnicType mainTechnic;
        public GameObject prefabMainTechnic;
        
        public TechnicType secondaryTechnic;
        public GameObject prefabSecondaryTechnic;
    }

    public List<CharacterInfo> characters;
}