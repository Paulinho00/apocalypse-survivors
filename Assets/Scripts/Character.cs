using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;

    public int armor = 0;

    [SerializeField] HealthBar healthBar;

    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }

    private void Start()
    {
        healthBar.SetState(currentHp, maxHp);
    }

    public void TakeDamage(int damage)
    {
        ApplyArmor(ref damage);

        currentHp -= damage;

        if(currentHp <= 0)
        {
            Debug.Log("Character is dead, GAME OVER");
        }

        healthBar.SetState(currentHp, maxHp);
    }

    private void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage < 0)
            damage = 0;
    }

    public void Heal(int amount)
    {
        if( currentHp <= 0) { return; }

        currentHp += amount;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        healthBar.SetState(currentHp, maxHp);
    }
}
