using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] private List<ItemScript> _woodList = new List<ItemScript>();
    [SerializeField] private List<ItemScript> _threadList = new List<ItemScript>();
    [SerializeField] private Transform _panel;
    [SerializeField] private GameObject _prefabSlot;
    [SerializeField] private byte _woodCount;
    [SerializeField] private byte _threadCount;
    [SerializeField] private int _itemCount;

    public byte WoodCount { get => _woodCount; set => _woodCount = value; }
    public byte ThreadCount { get => _threadCount; set => _threadCount = value; }
    public int ItemCount { get => _itemCount; set => _itemCount = value; }

    private void Update()
    {
        _itemCount = _woodCount + _threadCount;
    }

    private void UpdateUI()
    {
        foreach (Transform child in _panel)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in _woodList)
        {
            var slot = Instantiate(_prefabSlot, _panel);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;
            var itemIcon = slot.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.Icon;
        }
        foreach (var item in _threadList)
        {
            var slot = Instantiate(_prefabSlot, _panel);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;
            var itemIcon = slot.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.Icon;
        }
    }

    public void AddItem(ItemScript item)
    {
        if(item.Name == "Wood")
        {
            _woodList.Add(item);
            _woodCount++;
        }
        else if(item.Name == "Thread")
        {
            _threadList.Add(item);
            _threadCount++;
        }
        UpdateUI();
    }

    public void RemoveItem(ItemScript item, int count)
    {
        for(int i = 0; i < count; i++)
        {
            if (item.Name == "Wood")
            {
                _woodList.Remove(item);
                _woodCount--;
            }
            else if (item.Name == "Thread")
            {
                _threadList.Remove(item);
                _threadCount--;
            }
            UpdateUI();
        }

    }

    public void ClearInventory()
    {
        _woodList.Clear();
        _woodCount = 0;
        _threadList.Clear();
        _threadCount = 0;
        UpdateUI();
    }
}
