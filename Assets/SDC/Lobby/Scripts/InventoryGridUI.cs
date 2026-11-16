using UnityEngine;

public class InventoryGridUI: MonoBehaviour
{
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private int capacity;

    private void Start()
    {
        for(int i=0; i<capacity; i++)
        {
            Instantiate(itemSlotPrefab,content);
        }
    }

}
