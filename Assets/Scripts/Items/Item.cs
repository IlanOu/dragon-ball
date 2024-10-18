using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Race race = other.GetComponent<Race>();
        if (race != null)
        {
            IItemEffect itemEffect = GetComponent<IItemEffect>();

            if (itemEffect != null)
            {
                PlayerInfos.Instance.ApplyItemEffect(itemEffect);
            }

            Destroy(gameObject);
        }
    }
}