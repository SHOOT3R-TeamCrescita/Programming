using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAnim : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NoteManager.noteCombo != 0)
            anim.SetTrigger("isClick");
    }
}
