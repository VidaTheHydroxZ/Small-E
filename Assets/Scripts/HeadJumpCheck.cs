using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class HeadJumpCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.GetComponent<EnemyHeadCheck>())
         {
                Destroy(transform.parent.gameObject);
         }
    }
}

