using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteManager : MonoBehaviour
{
    public static bool isCheck = false;
    //public static bool isDie = false;
    //public static bool isColor = false;
    //public static bool isDamage = false;
    public static int noteCombo = 0;
    public static bool isLong = false;
    //public static bool isClick;

    public TextMeshProUGUI Combo;

    // Start is called before the first frame update
    void Start()
    {
        noteCombo = StatManager.curNoteCombo;
    }

    // Update is called once per frame
    void Update()
    {
        Combo.text = noteCombo.ToString();

        if (Input.GetMouseButtonDown(0) && !GameManager.isStop)
        {
            if (!isCheck)
                noteCombo-=3;
                //isClick = false;
            else if (isCheck)
                noteCombo++;
                //isClick = true;
                //isColor = true;
           // else if (isDie)
                //isColor = false;
               // noteCombo--;
        }

        if (noteCombo <= 0)
            noteCombo = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
            isCheck = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
            isCheck = false;
    }

}

