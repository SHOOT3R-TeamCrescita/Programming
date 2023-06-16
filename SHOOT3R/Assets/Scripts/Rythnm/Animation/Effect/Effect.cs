using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField]
    Animator effect;
    [SerializeField]
    Animator combo;
    [SerializeField]
    Animator vfx;
    [SerializeField]
    GameObject effect20;
    //[SerializeField]
    //Animator combobar;

    //public GameObject NM;

    public SFX_Player SFXPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NoteManager.noteCombo >= 20)
            effect20.SetActive(true);
        else
            effect20.SetActive(false);

        if (Input.GetMouseButtonDown(0) && !GameManager.isStop)
        {
            if (NoteManager.isCheck)
            {
                effect.SetBool("isEffect", true);
                combo.SetTrigger("isCombo");
                vfx.SetTrigger("isCombo");
                //combobar.SetBool("isCheck",true);
            }
            //else if (!NoteManager.isCheck || NoteManager.noteCombo == 0)
            //{
             //   combo.SetBool("isCombo", true);
            //}
        }
    }

    public void False()
    {
        effect.SetBool("isEffect", false);
       // combobar.SetBool("isCheck", false);
    }

    
}
