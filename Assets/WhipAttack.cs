using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttack : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerCharacter")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
    }
}
