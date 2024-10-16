using UnityEngine;

public class Namekian : Character
{

    private void Start()
    {
        // Default parameters for Namekians
        characterName = "Namekian";
    }
    
    public override void Attack()
    {
        Debug.Log(characterName + " attaque avec un Kamehameha !");
    }
}