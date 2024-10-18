using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    public GameObject map;
    public GameObject itemPrefab;
    public int numberOfItems;
    public float generationInterval;

    private Vector3 mapSize;

    void Start()
    {
       
        mapSize = map.GetComponent<Renderer>().bounds.size;

       
        StartCoroutine(GenerateItems());
    }

    IEnumerator GenerateItems()
    {
        int itemsGenerated = 0;

        while (itemsGenerated < numberOfItems)
        {
            // Générer un item
            GenerateItem();
            itemsGenerated++;

            // Attendre l'intervalle spécifié avant la prochaine génération
            yield return new WaitForSeconds(generationInterval);
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

        // Instancier l'item à la position calculée
        GameObject generatedItem = Instantiate(itemPrefab, randomPosition, Quaternion.identity);

        generatedItem.AddComponent<Item>();
        generatedItem.AddComponent<SpeedBoostItem>();
    }
}