using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private List<ItemScript> _itemList = new List<ItemScript>();
    [SerializeField] private Transform _panel;
    [SerializeField] private GameObject _prefabSlot;
    [SerializeField] private byte _itemCount;

    public byte ItemCount { get => _itemCount; set => _itemCount = value; }

    private void UpdateUI()
    {
        foreach (Transform child in _panel)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in _itemList)
        {
            var slot = Instantiate(_prefabSlot, _panel);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;
            var itemIcon = slot.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.Icon;
        }
    }

    public void AddItem(ItemScript item)
    {
        _itemList.Add(item);
        _itemCount++;
        UpdateUI();
    }

    public void RemoveItem(ItemScript item)
    {
        _itemList.Remove(item);
        _itemCount--;
        UpdateUI();
    }
}
