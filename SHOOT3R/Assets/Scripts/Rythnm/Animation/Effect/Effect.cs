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
    Animator combobar;

    //public GameObject NM;

    public SFX_Player SFXPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (NoteManager.isCheck)
            {
                effect.SetBool("isEffect", true);
                combo.SetBool("isCombo", true);
                combobar.SetBool("isCheck",true);
            }
            else if (!NoteManager.isCheck || NoteManager.noteCombo == 0)
            {
                combo.SetBool("isCombo", true);
            }
        }
    }

    public void False()
    {
        effect.SetBool("isEffect", false);
        combo.SetBool("isCombo", false);
        combobar.SetBool("isCheck", false);
    }

}
