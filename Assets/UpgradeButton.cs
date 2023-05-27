using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI text;

    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
        text.text = upgradeData.Name;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }
}
