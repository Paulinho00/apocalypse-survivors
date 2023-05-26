using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    WeaponManager weaponManager;

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
                break;
            case UpgradeType.ItemUpgrade:
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
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

        for(int i = 0; i < count; i++)
            upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]);

        return upgradeList;
    }

    internal void AddUpgradesIntoTheListOfAvaibleUpgrades(List<UpgradeData> upgradesToAdd)
    {
        this.upgrades.AddRange(upgradesToAdd);
    }
}
