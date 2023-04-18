using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class playerHP : MonoBehaviour
{
    public float PLhp = 100;
    public TextMeshProUGUI HP;
    public Image health;

    public Image damaged;

    public float color;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = PLhp.ToString("F0");
        

        health.fillAmount = PLhp / 200f;
        damaged.color = new Color(1f, 0f, 0f, color);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            StartCoroutine("Damaged");
            bool isCube = collision.gameObject.name.Contains("Cube");
            bool isMisile = collision.gameObject.name.Contains("Misile");
            bool isBall = collision.gameObject.name.Contains("Ball");

            if (isCube)
                PLhp -= 12f;
            else if (isMisile)
                PLhp -= 6f;
            else if (isBall)
                PLhp -= 4f;
        }
        
        if(collision.gameObject.layer == 12)
        {
            StartCoroutine("Damaged");
            PLhp -= 10f;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.layer == 11)
        {
            StartCoroutine("Damaged");
            bool isBarrier = collision.gameObject.name.Contains("Barrier");
            if (isBarrier)
                PLhp -= 0.06f;
        }
    }

    private IEnumerator Damaged()
    {
        color = 0.3f;
        while (color >= 0f)
        {
            color -= 0.01f;
            yield return new WaitForSeconds(1.5f/30f);
        }
    }

}
