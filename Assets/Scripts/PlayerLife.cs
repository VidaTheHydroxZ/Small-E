using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]private AudioSource Death;
    private Vector2 respawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("SpikedBall"))
        {
            Die();
            Death.Play();
        }
        if (collision.gameObject.CompareTag("Saw"))
        {
            Die();
            Death.Play();
        }
        if (collision.gameObject.CompareTag("FallDetector"))
        {
            Die();
            Death.Play();
        }
    }

    private void PlayerRestart()
    {
        transform.position = respawnPoint;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Die()
    {
    rb.bodyType = RigidbodyType2D.Static;
    anim.SetTrigger("death");
    Invoke("PlayerRestart", 2f);
    }

    
    /*
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    */
}
   
