using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    PauseManager pauseManager;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    private void Start()
    {
        HideButtons();
    }

    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }
    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pauseManager.PauseGame();
        panel.SetActive(true);

        for (int i = 0; i < upgradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void Clean()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
            upgradeButtons[i].Clean();
    }

    public void Upgrade(int pressedButtonId)
    {
        GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(pressedButtonId);
        ClosePanel();
    }

    public void ClosePanel()
    {
        HideButtons();

        pauseManager.UnPauseGame();
        panel.SetActive(false);
    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
            upgradeButtons[i].gameObject.SetActive(false);
    }
}
