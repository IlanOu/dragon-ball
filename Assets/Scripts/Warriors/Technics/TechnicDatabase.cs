using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TechnicDatabase", menuName = "Game/Technic Database")]
public class TechnicDatabase : ScriptableObject
{
    [System.Serializable]
    public class TechnicInfo
    {
        public string name;
        public TechnicType technicType;
        public RaceType raceType;
        public GameObject prefabTechnic;
    }

    public List<TechnicInfo> Technics;
}