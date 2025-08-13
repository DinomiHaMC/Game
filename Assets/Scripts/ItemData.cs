using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public int maxLevel = 3;

    public float[] durabilityPerLevel;
    public float[] efficiencyPerLevel;
}
