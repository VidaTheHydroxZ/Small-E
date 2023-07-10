using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadCheck : MonoBehaviour
{

    [SerializeField] private Rigidbody2D PlayerEnemyHeadCheck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHeadCheck>())
        {
            PlayerEnemyHeadCheck.velocity = new Vector2(PlayerEnemyHeadCheck.velocity.x, 0f);
            PlayerEnemyHeadCheck.AddForce(Vector2.up * 300f);
        }
    }
}
