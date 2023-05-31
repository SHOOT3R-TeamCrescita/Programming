using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tower : MonoBehaviour
{
    public float towergage;
    //public TextMeshProUGUI TG;
    [SerializeField] GameObject TUI;
    [SerializeField] Image Tgage;
    [SerializeField] Image TUIgage;

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
                TUI.SetActive(false);
                GameManager.towercount++;
                isCount = false;
            }
        }

        //TG.text = towergage.ToString("F0");

        Tgage.fillAmount = towergage / 100;
        TUIgage.fillAmount = towergage / 100;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player")&&towergage<100)
        {
            towergage += 0.6f;
            TUI.SetActive(true);
        }

        if (collision.gameObject.layer == 10 && towergage <100)
        {
            towergage -= 0.2f;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            TUI.SetActive(false);
    }
}
