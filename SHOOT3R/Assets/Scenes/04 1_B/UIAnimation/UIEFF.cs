using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEFF : MonoBehaviour
{
    [SerializeField] GameObject first;
    [SerializeField] GameObject second;
    [SerializeField] GameObject third;
    [SerializeField] GameObject rank;

    void Start()
    {
        Invoke("FIRST", 1.0f);    
    }


    public void FIRST()
    {
        first.SetActive(true);
        Invoke("SECOND", 1.0f);
    }

    public void SECOND()
    {
        second.SetActive(true);
        Invoke("THIRD", 1.0f);
    }

    public void THIRD()
    {
        third.SetActive(true);
        Invoke("Rank", 1.0f);
    }

    public void Rank()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        rank.SetActive(true);
    }
}
