using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCreater : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    public int noteCount = 0;
    
    [SerializeField] Transform spawn = null;
    [SerializeField] GameObject note = null;

    public GameObject longNote;
    public AudioSource music;

    void Start()
    {
        longNote.SetActive(false);
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 30d/bpm)
        {
            /*
            if(noteCount%4 != 0 && noteCount <= 60)
            {
                currentTime -= 30d / bpm;
                noteCount++;
            }
            else 
            {
                GameObject t_note = Instantiate(note, spawn.position, Quaternion.identity);
                t_note.transform.SetParent(this.transform);
                currentTime -= 30d / bpm;
                noteCount++;
            }
           */
            
            if (noteCount % 2 != 1 || (noteCount >= 390 && noteCount <= 400))
            {
                currentTime -= 30d / bpm;
                noteCount++;
            }
            else if ((noteCount >= 100 && noteCount <= 160) || (noteCount >= 300 && noteCount <= 360))
            {
                longNote.SetActive(true);
                NoteManager.isLong = true;
                currentTime -= 30d / bpm;
                noteCount++;
            }
            else if(noteCount > 400)
            {
                currentTime -= 30d / bpm;
                noteCount = 0;
                music.Play();
            }
            else
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                GameObject t_note = Instantiate(note, spawn.position, Quaternion.identity);
                t_note.transform.SetParent(this.transform);
                currentTime -= 30d / bpm;
                noteCount++;
            }
        }
    }
}
