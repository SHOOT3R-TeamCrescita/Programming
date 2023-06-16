using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody bulletS;
    public bool isColor;

    [SerializeField]
    GameObject effect;
    [SerializeField]
    GameObject effect1;

    private void Awake()
    {
        bulletS = GetComponent<Rigidbody>();
    }

    void Start()
    {
        bulletS.velocity = transform.forward * 400f + transform.up * 5f;

        //bulletS.AddForce(Vector3.forward * 20f,ForceMode.Impulse);
        //isColor = NoteManager.isColor;
        ColorChange();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine("Timer");

        if (collision.gameObject.CompareTag("Boss"))
        {
      
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("Zaco"))
        {
            Instantiate(effect1, transform.position, Quaternion.identity);
        }
    }

    void ColorChange()
    {
        /*
        if (isColor == true)
        {
            bulletS.GetComponent<Renderer>().material.color = Color.blue;
            isColor = false;
            //EnemyTest.isDamage = true;
            //BossHP.isDamage = true;
            NoteManager.isDamage = true;
        }*/

        if (NoteManager.isLong == true)
            bulletS.GetComponent<Renderer>().material.color = Color.yellow;
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
