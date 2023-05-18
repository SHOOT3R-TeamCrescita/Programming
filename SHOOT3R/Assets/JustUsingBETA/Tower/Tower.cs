using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    public float towergage;
    public TextMeshProUGUI TG;

    bool isCount = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (towergage < 0)
            towergage = 0;
        else if (towergage > 100)
        { 
            towergage = 100;
            if(isCount)
            {
                GameManager.towercount++;
                isCount = false;
            }
        }

        TG.text = towergage.ToString("F0");
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            towergage += 1.0f;
        }

        if (collision.gameObject.layer == 10 && towergage <100)
        {
            towergage -= 0.01f;
        }

    }
}
