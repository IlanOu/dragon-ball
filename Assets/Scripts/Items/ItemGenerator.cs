using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject map;
    public GameObject itemPrefab;
    public float generationInterval;

    private Vector3 mapSize;
    private float timeSinceLastGeneration;
    private GameObject currentItem;

    void Start()
    {
        mapSize = map.GetComponent<Renderer>().bounds.size;
        timeSinceLastGeneration = generationInterval; // Pour générer un item immédiatement au démarrage
    }

    void Update()
    {
        if (currentItem == null)
        {
            timeSinceLastGeneration += Time.deltaTime;

            if (timeSinceLastGeneration >= generationInterval)
            {
                GenerateItem();
                timeSinceLastGeneration = 0f;
            }
        }
    }

    void GenerateItem()
    {
        // Calculer une position aléatoire sur la map
        Vector3 randomPosition = new Vector3(
            Random.Range(-mapSize.x / 2, mapSize.x / 2),
            0, // Supposons que les items sont générés au niveau du sol
            Random.Range(-mapSize.z / 2, mapSize.z / 2)
        );

        // Ajuster la position par rapport à la position de la map
        randomPosition += map.transform.position;
        randomPosition.y += 0.5f;

        // Instancier l'item à la position calculée
        currentItem = Instantiate(itemPrefab, randomPosition, Quaternion.identity);

        currentItem.AddComponent<Item>();
        currentItem.AddComponent<SpeedBoostItem>();

        // Ajouter un composant pour détecter la destruction de l'item
        ItemDestructionDetector detector = currentItem.AddComponent<ItemDestructionDetector>();
        detector.OnItemDestroyed += OnItemDestroyed;
    }

    void OnItemDestroyed()
    {
        // L'item a été détruit, on peut en générer un nouveau après l'intervalle
        currentItem = null;
        timeSinceLastGeneration = 0f;
    }
}

// Nouveau composant pour détecter la destruction de l'item
public class ItemDestructionDetector : MonoBehaviour
{
    public delegate void ItemDestroyedHandler();
    public event ItemDestroyedHandler OnItemDestroyed;

    private void OnDestroy()
    {
        OnItemDestroyed?.Invoke();
    }
}