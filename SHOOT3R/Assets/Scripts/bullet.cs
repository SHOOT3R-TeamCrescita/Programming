using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody bulletS;

    private void Awake()
    {
        bulletS = GetComponent<Rigidbody>();
    }

    void Start()
    {
        bulletS.velocity = transform.forward * 200f + transform.up * 10f;
        ColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
            StartCoroutine("Timer");
    }

    void ColorChange()
    {
        if (NoteMove.isColor == true)
        {
            bulletS.GetComponent<Renderer>().material.color = Color.blue;
            NoteMove.isColor = false;
            EnemyTest.isDamage = true;
        }

        if (NoteCreater.isLong == true)
            bulletS.GetComponent<Renderer>().material.color = Color.cyan;
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            OnDestroy();
        }

    }

    void OnDestroy()
    {
        Destroy(gameObject);
    }
}
