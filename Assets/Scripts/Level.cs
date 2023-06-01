using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    int level = 1;
    int expierence = 0;
    [SerializeField] ExpierenceBar expierenceBar;
    [SerializeField] UpgradePanelManager upgradePanel;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;
    [SerializeField] List<UpgradeData> upgradesAvailableOnStart;

    WeaponManager weaponManager;
    PassiveItems passiveItems;

    int expToLevelUp
    {
        get
        {
            return level * 1000;
        }
    }

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        passiveItems = GetComponent<PassiveItems>();
        AddUpgradesIntoTheListOfAvaibleUpgrades(upgradesAvailableOnStart);
    }

    private void Start()
    {
        expierenceBar.UpdateExpierenceSlider(expierence, expToLevelUp);
        expierenceBar.SetLeveltext(level);
    }

    public void AddExpierence(int amount)
    {
        expierence += amount;
        CheckLevelUp();
        expierenceBar.UpdateExpierenceSlider(expierence, expToLevelUp);
    }

    public void Upgrade(int selectedUpgradeId)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeId];

        if(acquiredUpgrades == null)
            acquiredUpgrades = new List<UpgradeData>();

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.UpgradeItem(upgradeData);
                break;
            case UpgradeType.WeaponGet:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemGet:
                passiveItems.Equip(upgradeData.item);
                AddUpgradesIntoTheListOfAvaibleUpgrades(upgradeData.item.upgrades);
                break;
        }

        acquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    public void CheckLevelUp()
    {
        if (expierence >= expToLevelUp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if (selectedUpgrades == null)
            selectedUpgrades = new List<UpgradeData>();
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(3));

        upgradePanel.OpenPanel(selectedUpgrades);
        expierence -= expToLevelUp;
        level += 1;
        expierenceBar.SetLeveltext(level);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if(count > upgrades.Count)
            count = upgrades.Count;

        System.Random random = new System.Random();
        List<int> selectedIndices = new List<int>();

        while (selectedIndices.Count < count)
        {
            int randomIndex = random.Next(0, upgrades.Count);

            if (!selectedIndices.Contains(randomIndex))
                selectedIndices.Add(randomIndex);
        }

        for (int i = 0; i < count; i++)
            upgradeList.Add(upgrades[selectedIndices[i]]);

        return upgradeList;
    }

    internal void AddUpgradesIntoTheListOfAvaibleUpgrades(List<UpgradeData> upgradesToAdd)
    {
        if (upgradesToAdd == null)
            return;

        this.upgrades.AddRange(upgradesToAdd);
    }
}
