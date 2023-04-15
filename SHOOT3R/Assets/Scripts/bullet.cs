using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody bulletS;
    public bool isColor;

    private void Awake()
    {
        bulletS = GetComponent<Rigidbody>();
    }

    void Start()
    {
        bulletS.velocity = transform.forward * 200f + transform.up * 10f;

        //bulletS.AddForce(Vector3.forward * 20f,ForceMode.Impulse);
        isColor = NoteMove.isColor;
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
        if (isColor == true)
        {
            bulletS.GetComponent<Renderer>().material.color = Color.blue;
            isColor = false;
            //EnemyTest.isDamage = true;
            //BossHP.isDamage = true;
            NoteMove.isDamage = true;
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
