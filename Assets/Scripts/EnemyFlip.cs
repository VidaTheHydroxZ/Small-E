using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 15f;
    private SpriteRenderer PigSprite;
    private Animator _pigAnimation;
    private string _currentState;
    const string PIG_IDLE = "PigWalking";
    const string PIG_HIT = "PigHit";

    void Start()
    {
        PigSprite = GetComponent<SpriteRenderer>();
        _pigAnimation = gameObject.AddComponent<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            PigSprite.flipX = true;
            if (currentWaypointIndex >= waypoints.Length)
            {
                PigSprite.flipX = false;
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);


    }
    /*
    private void ChangeAnimationState(string newState)
    {
        if (newState == _currentState)
        {
            return;
        }

        _pigAnimation.Play(newState);

        _currentState = newState;
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyHeadCheck"))
        {
            _pigAnimation.SetTrigger("Hit");
            _pigAnimation.Play("PigHit");
        }
    }


}
