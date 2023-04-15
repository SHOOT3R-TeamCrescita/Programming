using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    private Vector3 direction;

    public bool isCheck = false;
    bool isDie = false;
    public static bool isColor = false;
    public static bool isDamage = false;

    public Animator anim;

    void Start()
    {
        direction = Vector3.right;

        anim = GetComponent<Animator>();

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isCheck)
            {
                NoteCreater.noteClick++;
                NoteCreater.noteCombo++;
                isColor = true;

                Destroy(gameObject);
            }
            else if (isDie)
            {
                isColor = false;
                NoteCreater.noteCombo = 0;
            }
        }
    
        transform.position += direction * 510f * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
            isCheck = true;
        else if (collision.CompareTag("Destroy"))
        {
            isColor = false;
            Destroy(gameObject);
            NoteCreater.noteCombo = 0;
        }
        else if (collision.CompareTag("DeathCheck"))
            isDie = true;
            

        if (collision.CompareTag("Visual"))
            anim.SetBool("isStart", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
            isCheck = false;

        if (collision.CompareTag("Visual"))
            anim.SetBool("isStart", false);

        else if (collision.CompareTag("DeathCheck"))
            isDie = false;
    }

}
