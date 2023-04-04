using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCreater : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    public int noteCount = 1;
    public static int noteClick = 0;
    public static bool isLong = false;

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
            /*GameObject t_note = Instantiate(note, spawn.position, Quaternion.identity);
            t_note.transform.SetParent(this.transform);
            currentTime -= 30d / bpm;
            noteCount++;*/

            if (/*(noteCount-2)%4==0 && noteCount!=0 || noteCount == 1 || noteCount ==2*/noteCount%2==0 || (noteCount>=441&&noteCount<=444) )
            {
                currentTime -= 30d / bpm;
                noteCount++;
            }
            else if((noteCount >= 10 && noteCount <= 60) || (noteCount>=300 && noteCount <= 360))
            {
                longNote.SetActive(true);
                isLong = true;
                noteCount++;
            }
            else if(noteCount > 445)
            {
                noteCount = 1;
                music.Play();
            }
            else
            {
                longNote.SetActive(false);
                isLong = false;
                GameObject t_note = Instantiate(note, spawn.position, Quaternion.identity);
                t_note.transform.SetParent(this.transform);
                currentTime -= 30d / bpm;
                noteCount++;
            }
            
        }
    }
}
