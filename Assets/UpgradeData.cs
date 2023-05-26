using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock
}

public class UpgradeData : ScriptableObject
{
    UpgradeType upgradeType;
}
