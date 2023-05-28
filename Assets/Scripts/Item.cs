using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemStats
{
    public int armor;
    public float regenerationRate;

    internal void Sum(ItemStats stats)
    {
        armor += stats.armor;
        regenerationRate += stats.regenerationRate;
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemStats stats;
    public List<UpgradeData> upgrades;

    public void Init(string Name)
    {
        this.Name = Name;
        stats = new ItemStats();
        upgrades = new List<UpgradeData>();
    }

    public void Equip(Character character)
    {
        character.armor += stats.armor;
        character.hpRegenerationRate += stats.regenerationRate;
    }

    public void UnEquip(Character character)
    {
        character.armor -= stats.armor;
        character.hpRegenerationRate -= stats.regenerationRate;
    }
}
