using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Misile : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;
    float a;


    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Timer");
        StartCoroutine("Height");
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(target.position);
        
    }

    private IEnumerator Height()
    {
        while (nav.baseOffset > 1.5f)
        {
            a += 0.01f;
            nav.baseOffset -= a;
            yield return new WaitForFixedUpdate();

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            OnDestroy();
    }
    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            OnDestroy();
        }

    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }

}
