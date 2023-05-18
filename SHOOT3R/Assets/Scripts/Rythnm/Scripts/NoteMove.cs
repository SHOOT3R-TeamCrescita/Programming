using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    private Vector3 direction;

    public Animator anim;

    bool isCheck;
    bool isDie;

    void Start()
    {
        direction = Vector3.right;

        anim = GetComponent<Animator>();

        //isClick = NoteManager.isClick;
    }


    void Update()
    {
        transform.position += direction * NoteCreater.noteSpeed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && isCheck)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
        {
            isCheck = true;
        }
        else if (collision.CompareTag("Destroy"))
        {
            //NoteManager.isColor = false;
            Destroy(gameObject);
            NoteManager.noteCombo-=5;
        }
        //else if (collision.CompareTag("DeathCheck"))
            //NoteManager.isDie = true;
            

        if (collision.CompareTag("Visual"))
            anim.SetBool("isStart", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
        {
            isCheck = false;
        }
        if (collision.CompareTag("Visual"))
            anim.SetBool("isStart", false);

        //else if (collision.CompareTag("DeathCheck"))
            //NoteManager.isDie = false;
    }
}
