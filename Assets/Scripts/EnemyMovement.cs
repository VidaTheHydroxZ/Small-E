using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class EnemyMovement : MonoBehaviour
{
    private float dirX;
    [SerializeField]private float moveSpeed;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 localScale;
    private bool facingRight = false;
    private Transform target;
    private bool moving = true;


    private void Start()
    {
        localScale = transform.localScale;  
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        moveSpeed = 7f;
        

    }
   

    void Update()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
       
        CheckWhereToFace();
    }


    void CheckWhereToFace()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

}
