using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    // Variables configurables depuis l'inspecteur
    public float rotationSpeed = 50f;  // Vitesse de la rotation
    public float floatAmplitude = 0.5f;  // Amplitude du mouvement de flottaison
    public float floatFrequency = 1f;  // Fréquence de la flottaison

    // Position de départ en Y
    private Vector3 startPosition;

    void Start()
    {
        // Sauvegarder la position de départ de l'objet
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotation infinie autour de l'axe Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Mouvement de flottaison en Y basé sur une onde sinusoïdale
        float newY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}