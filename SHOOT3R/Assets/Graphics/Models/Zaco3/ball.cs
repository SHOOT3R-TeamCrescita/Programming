using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody balls;


    private void Awake()
    {
        balls = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        balls.velocity = transform.forward * 100f + transform.up * 4f;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            OnDestroy();

        else
            StartCoroutine("Timer");

    }

        private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            OnDestroy();
        }

    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
