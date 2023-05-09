using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    [SerializeField] float speed;
    [SerializeField] int hp = 999;
    [SerializeField] int damage = 1;
    GameObject targetGameObject;

    [SerializeField] int expierenceReward = 400;


    Character targetCharacter;
    Rigidbody2D rigidBody2d;

    private void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rigidBody2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetDestination.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExpierence(expierenceReward);
            Destroy(gameObject);
        }
    }
}
