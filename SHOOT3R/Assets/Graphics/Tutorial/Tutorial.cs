using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] tuto;
    [SerializeField] GameObject noteCreater;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        noteCreater.GetComponent<NoteCreater>().music.Pause();
        GameManager.isStop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            count++;
            NextClick();
        }

        if(count > 4)
        {
            GameManager.isStop = false;
            GameManager.towercount = 0;
            GameManager.stoptime = 1;
            Time.timeScale = 1;
            NoteManager.noteCombo = 0;
            noteCreater.GetComponent<NoteCreater>().music.Play();
            Destroy(gameObject);
        }
    }

    void NextClick()
    {
        for (int i = 0; i < tuto.Length; i++)
        {
            if (i == count)
            {
               tuto[i].SetActive(true); 
            }
            else
            {
                tuto[i].SetActive(false); 
            }
        }
    }
}
