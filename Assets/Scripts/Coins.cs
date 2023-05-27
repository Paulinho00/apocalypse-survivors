using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] DataContainer data;
    
    public void Add(int count)
    {
        data.coins += count;
    }
}
