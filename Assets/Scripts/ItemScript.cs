using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class ItemScript : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public string Name { get => _name; set => _name = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
}
