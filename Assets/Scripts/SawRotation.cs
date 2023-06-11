using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private void Update()
    {
       transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
