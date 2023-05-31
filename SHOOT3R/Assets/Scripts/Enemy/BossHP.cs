using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public float BShp;
    public float MaxBShp;
    public static bool dotHP = false;
    //public static bool isDamage = false;
    public TextMeshProUGUI HP;
    public Image health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = BShp.ToString("F0");

        if (dotHP)
            BShp += 0.2f;

        health.fillAmount = BShp / MaxBShp;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //BShp -= 10;
            //if (NoteMove.isDamage == true)
            //{
                BShp -= 10f *(1f + ((float)NoteManager.noteCombo / 100f ));
               // NoteManager.isDamage = false;
            //}
            if (NoteManager.isLong == true)
            {
                BShp -= 2f;
            }    
        }
    }
}
