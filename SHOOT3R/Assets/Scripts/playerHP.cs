using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerHP : MonoBehaviour
{
    public float PLhp = 100;
    public TextMeshProUGUI HP;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = PLhp.ToString("F0");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            bool isCube = collision.gameObject.name.Contains("Cube");
            bool isMisile = collision.gameObject.name.Contains("Misile");

            if (isCube)
                PLhp -= 12f;
            else if (isMisile)
                PLhp -= 6f;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.layer == 11)
        {
            bool isBarrier = collision.gameObject.name.Contains("Barrier");
            if (isBarrier)
                PLhp -= 0.06f;
        }
    }

}
