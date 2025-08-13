using UnityEngine;

public class ItemInstance
{
    public AxeScript _axe;
    public ItemData data;
    public int currentLevel = 1;
    public float currentDurability;

    public ItemInstance(ItemData data)
    {
        this.data = data;
        currentLevel = 1;
        currentDurability = data.durabilityPerLevel[0];
    }

    public float GetEffeciency() => data.efficiencyPerLevel[currentLevel - 1];

    public float GetDurability() => data.durabilityPerLevel[currentLevel - 1];

    public void Repair()
    {
        currentDurability = GetDurability();
    }

    public bool Upgrade()
    {
        if (currentLevel >= data.maxLevel)
            return false;
        currentLevel++;

        Repair();
        return true;
    }

    public void Use(float amount)
    {
        currentDurability -= amount;
        currentDurability = Mathf.Max(currentDurability);
    }

    public bool IsBroken => currentDurability <= 0;
}
