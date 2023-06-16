using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    public AudioSource hit;

    void Start()
    {
        hit = GetComponent<AudioSource>();
    }
    void Update()
    {
    
   }

    void OnCollisionEnter(Collision collision)
    {
    if (collision.gameObject.layer == 8)
       {
          hit.Play();
       }
    }
}
