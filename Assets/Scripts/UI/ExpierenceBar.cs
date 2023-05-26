using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpierenceBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    public void UpdateExpierenceSlider(int current, int target)
    {
        slider.maxValue = target;
        slider.value = current;
    }

    public void SetLeveltext(int level)
    {
        levelText.text = "LEVEL: " + level.ToString();
    }
}
