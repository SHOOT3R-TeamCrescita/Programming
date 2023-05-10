using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public GameObject bulletS;
    //public static bool isDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.7f, 0.1f);

            /*if (NoteManager.isDamage == true)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                NoteManager.isDamage = false;
            }*/
        }
                
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8)
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
