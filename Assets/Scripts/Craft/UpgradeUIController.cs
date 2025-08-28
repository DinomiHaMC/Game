using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemLevel;
    [SerializeField] private TextMeshProUGUI _itemDurability;
    [SerializeField] private TextMeshProUGUI _itemEffeciency;

    [SerializeField] private Button _repair;
    [SerializeField] private Button _upgrade;

    private ItemInstance _currentItem;

    [SerializeField] private InventoryScript _inventory;
    [SerializeField] private ItemScript _thread;
    [SerializeField] private ItemScript _wood;

    public void SetItem(ItemInstance item)
    {
        _currentItem = item;
        _currentItem._inventory = _inventory;
        UpdateUI();
    }

    public void Repair()
    {
        if(_currentItem == null || !_inventory.CheckItem(_thread, 1)) return;
        _currentItem.Repair();
        _inventory.RemoveItem(_thread, 1);
        UpdateUI();
    }

    public void Updrade()
    {
        if (_currentItem == null) { print("No item"); return; }
        if (_currentItem.Upgrade())
        {
            print(_currentItem.Upgrade());
            _inventory.RemoveItem(_wood, 2);
            _inventory.RemoveItem(_thread, 1);
            UpdateUI();
            return;
        }
        else
        {
            return;
        }
    }

    private void UpdateUI()
    {
        _itemName.text = _currentItem.data.name;
        _itemLevel.text = $"LVL: {_currentItem.currentLevel}";
        _itemDurability.text = $"Dur.: {_currentItem.currentDurability}";
        _itemEffeciency.text = $"Eff.: {_currentItem.GetEffeciency()}";

        _upgrade.interactable = _currentItem.currentLevel < _currentItem.data.maxLevel;
    }
}
