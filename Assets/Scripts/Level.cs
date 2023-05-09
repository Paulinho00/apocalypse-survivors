using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level = 1;
    int expierence = 0;
    [SerializeField] ExpierenceBar expierenceBar;

    int expToLevelUp
    {
        get
        {
            return level * 1000;
        }
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

    public void CheckLevelUp()
    {
        if (expierence >= expToLevelUp)
        {
            expierence -= expToLevelUp;
            level += 1;
            expierenceBar.SetLeveltext(level);
        }
    }
}
