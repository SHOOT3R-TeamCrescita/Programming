using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    Rigidbody cube;
    // Start is called before the first frame update
    void Awake()
    {
        cube = GetComponent<Rigidbody>();
    }

    void Start()
    {
        cube.velocity = transform.forward * 50f + transform.up * 25f;

        //cube.AddForce(Vector3.forward * 200f,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
            StartCoroutine("Timer");
    }
    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            OnDestroy();
        }

    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
