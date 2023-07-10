using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private AudioSource CheckpointSound;
    private bool CheckpointEnabled = false;

    void Start()
    {
        CheckpointSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !CheckpointEnabled)
        {
            CheckpointSound.Play();
            CheckpointEnabled = true;
        }
    }

   
}
