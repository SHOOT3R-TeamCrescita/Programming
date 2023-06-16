using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    private Vector3 direction;

    public Animator anim;

    bool isCheck;
    bool isDie = true;

    void Start()
    {
        direction = Vector3.right;

        anim = GetComponent<Animator>();

        //isClick = NoteManager.isClick;
    }


    void Update()
    {
        if (isDie)
            transform.position += direction * NoteCreater.noteSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && isCheck && !GameManager.isStop)
        {
            isDie = false;
            anim.SetTrigger("isNote");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
            isCheck = true;

        if (collision.CompareTag("Destroy"))
        {
            //NoteManager.isColor = false;
            Destroy(gameObject);
            NoteManager.noteCombo--;
        }
        //else if (collision.CompareTag("DeathCheck"))
            //NoteManager.isDie = true; 

        if (collision.CompareTag("Visual"))
            anim.SetBool("isStart", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
            isCheck = false;

        if (collision.CompareTag("Visual"))
            anim.SetBool("isStart", false);

        //else if (collision.CompareTag("DeathCheck"))
            //NoteManager.isDie = false;
    }

    public void NoteDestroy() 
    { 
        Destroy(gameObject);
    }
}
