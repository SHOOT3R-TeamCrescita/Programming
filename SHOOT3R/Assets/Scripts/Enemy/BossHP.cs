using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossHP : MonoBehaviour
{
    public float BShp;
    public static bool dotHP = false;
    //public static bool isDamage = false;
    public TextMeshProUGUI HP;

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

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            BShp -= 10;
            if (NoteMove.isDamage == true)
            {
                BShp -= 30f *(1f + ((float)NoteCreater.noteCombo / 100f ));
                NoteMove.isDamage = false;
            }
            else if (NoteCreater.isLong == true)
            {
                BShp += 8f;
            }    
        }
    }
}
