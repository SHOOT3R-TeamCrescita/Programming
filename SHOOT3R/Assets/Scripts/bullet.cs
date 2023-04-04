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
        bulletS.velocity = transform.forward * 100f + transform.up * 20f;
        ColorChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
            Destroy(gameObject);
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
}
