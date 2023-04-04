using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    private Vector3 direction;

    public bool isCheck = false;
    public static bool isColor = false;

    public Animator anim;


    void Start()
    {
        direction = Vector3.right;

        anim = GetComponent<Animator>();

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCheck == true)
        {
            isColor = true;
            NoteCreater.noteClick++;
            Debug.Log(NoteCreater.noteClick);
            Destroy(gameObject);
        }
        transform.position += direction * 510f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
            isCheck = true;
        else if (collision.CompareTag("Destroy"))
            Destroy(gameObject);

        if (collision.CompareTag("Visual"))
            anim.SetBool("isStart", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Check"))
            isCheck = false;

        if (collision.CompareTag("Visual"))
            anim.SetBool("isStart", false);
    }

}
