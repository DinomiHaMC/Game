
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private bool _flag = false;

    [SerializeField] private ItemScript _item;
    private void OnTriggerEnter(Collider other)
    {
        InventoryScript inventoryScript = other.GetComponent<InventoryScript>();
        if (inventoryScript != null && inventoryScript.ItemCount < 5 && _flag == false)
        {
            inventoryScript.AddItem(_item);
            _flag = true;
            Destroy(gameObject);
        }
    }
}
