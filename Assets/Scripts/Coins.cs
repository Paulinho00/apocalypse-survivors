using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAcquired;

    public void Add(int count)
    {
        coinAcquired += count;
    }
}
