using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    public float towergage;
    public TextMeshProUGUI TG;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (towergage < 0)
            towergage = 0;

        TG.text = towergage.ToString("F0");
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            towergage += 0.05f;
        }

        if (collision.gameObject.layer == 10)
        {
            towergage -= 0.01f;
        }

    }
}
