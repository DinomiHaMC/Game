using System;
using NUnit.Framework;
using UnityEngine;

[Serializable]
public class UpgradeLevelData
{
    public float durability;
    public float efficiency;

    public List<UpgradeRequirement> requirement;
}
