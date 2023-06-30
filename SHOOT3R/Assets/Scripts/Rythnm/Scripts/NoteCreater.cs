using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NoteCreater : MonoBehaviour
{
    public int bpm = 0;
    //public double currentTime = 0d;

    public int noteCount = 0;

    public float stageCheck;
    public static float noteSpeed;
    
    [SerializeField] Transform spawn = null;
    [SerializeField] GameObject note = null;

    public GameObject longNote;
    public AudioSource music;

    public float test;
    [SerializeField] private Intervals[] _intervals;

    public bool isTe;
    //public TextMeshProUGUI NC;

    void Start()
    {
        longNote.SetActive(false);
    }
    void Update()
    {
        //currentTime += Time.deltaTime;
        //NC.text = noteCount.ToString();
        //NC.text = StatManager.Contuinue.ToString();

        foreach (Intervals interval in _intervals)
        {
            test = music.timeSamples / (music.clip.frequency * interval.GetIntervalLength(bpm));
            interval.CheckForNewInterval(test);
        }

        switch (stageCheck)
        {
            case 1.0f:
                Stage1N();
                break;
            case 1.5f:
                Stage1B();
                break;
        }
    }

    void Stage1N()
    {
        noteSpeed = 515f;

       if (isTe)
       {
            if (noteCount % 4 == 3 && noteCount > 2 && noteCount < 66) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                //currentTime -= 30d / bpm;
                //noteCount++;
                isTe = false;
            }
            else if (noteCount % 4 == 1 && ((noteCount > 196 && noteCount < 260) || (noteCount > 388 && noteCount < 448))) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
                //currentTime -= 30d / bpm;
                //noteCount++;
            }
            else if(noteCount % 2 == 1 && noteCount>66 && noteCount<196) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
                //currentTime -= 30d / bpm;
                //noteCount++;
            }
            else if ((noteCount%8==4||noteCount%8==7 || noteCount % 8 == 1) &&(noteCount>260&&noteCount<388)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
                //currentTime -= 30d / bpm;
                //noteCount++;
            }
            else if ((noteCount%16==3||noteCount%16==5||noteCount%16==7||noteCount%16==9||noteCount%16==10||noteCount%16==12||noteCount%16==14||noteCount%16==0) && (noteCount > 448 && noteCount < 580)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
                //currentTime -= 30d / bpm;
                //noteCount++;
            }
            else if(noteCount>=580)
            {
                noteCount = 0;
                isTe = false;
                //currentTime = 0;
                //noteCount++;
            }
       }
    }

    void Stage1B()
    {
        noteSpeed = 480f;

        if (isTe)
        {
            if ((noteCount >= 1600 && noteCount <= 2400) || (noteCount >= 5000 && noteCount <= 5600)) //�ճ�Ʈ
            {
                longNote.SetActive(true);
                NoteManager.isLong = true;
                isTe = false;
            }
            else if (noteCount < 28) //��Ʈ �����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                isTe = false;
            }
            else if (noteCount % 2 == 1&&(noteCount>28&&noteCount<92)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 0|| noteCount % 8 == 1 || noteCount % 8 == 4 || noteCount % 8 == 5) && (noteCount > 92 && noteCount < 156)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 0 || noteCount % 8 == 2 || noteCount % 8 == 3 || noteCount % 8 == 4) && (noteCount > 156 && noteCount < 220)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 0 || noteCount % 8 == 2 || noteCount % 8 == 4 || noteCount % 8 == 5) && (noteCount > 220 && noteCount < 284)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if (((noteCount % 8 == 0 || noteCount % 8 == 3) && (noteCount >= 284 && noteCount < 308))||noteCount==309 || noteCount==311||noteCount==313) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 4 == 0 || noteCount % 4 == 1)&&(noteCount > 316 && noteCount < 380)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 0 || noteCount % 8 == 2 || noteCount % 8 == 5 || noteCount % 8 == 6) && (noteCount > 380 && noteCount < 444)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 1 || noteCount % 8 == 2 || noteCount % 8 == 4 || noteCount % 8 == 5 || noteCount % 8 == 7) && (noteCount > 444 && noteCount < 508)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 0 || noteCount % 8 == 3 || noteCount % 8 == 5 || noteCount % 8 == 6) && (noteCount > 508 && noteCount < 572)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 1 || noteCount % 8 == 4 || noteCount % 8 == 7) && (noteCount > 572 && noteCount < 636)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 1 || noteCount % 8 == 2 || noteCount % 8 == 3 || noteCount % 8 == 5 || noteCount % 8 == 6) && (noteCount > 636 && noteCount < 700)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 1 || noteCount % 8 == 2 || noteCount % 8 == 3 || noteCount % 8 == 4) && (noteCount > 700 && noteCount < 764)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 8 == 0 || noteCount % 8 == 3 || noteCount % 8 == 4 || noteCount % 8 == 6) && (noteCount > 764 && noteCount < 830)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if (((noteCount % 8 == 0 || noteCount % 8 == 3) && (noteCount >= 830 && noteCount < 854)) || noteCount == 855 || noteCount == 857 || noteCount == 859) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount%16==0|| noteCount % 16 == 3 || noteCount % 16 == 4 || noteCount % 16 == 6 || noteCount % 16 == 9 || noteCount % 16 == 12 || noteCount % 16 == 13) && (noteCount > 862 && noteCount < 926)) //��Ʈ ����
            {
                longNote.SetActive(true);
                NoteManager.isLong = true;
                isTe = false;
            }
            else if ((noteCount % 16 == 0 || noteCount % 16 == 1 || noteCount % 16 == 4 || noteCount % 16 == 6 || noteCount % 16 == 9 || noteCount % 16 == 10 || noteCount % 16 == 12 || noteCount % 16 == 15) && (noteCount > 926 && noteCount < 990)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 16 == 1 || noteCount % 16 == 2 || noteCount % 16 == 5 || noteCount % 16 == 6 || noteCount % 16 == 11 || noteCount % 16 == 12 || noteCount % 16 == 14 || noteCount % 16 == 15) && (noteCount > 990 && noteCount < 1054)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 16 == 1 || noteCount % 16 == 3 || noteCount % 16 == 4 || noteCount % 16 == 5 || noteCount % 16 == 8 || noteCount % 16 == 9 || noteCount % 16 == 10 || noteCount % 16 == 13 || noteCount % 16 == 14) && (noteCount > 1054 && noteCount < 1118)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 16 == 0 || noteCount % 16 == 3 || noteCount % 16 == 6 || noteCount % 16 == 7 || noteCount % 16 == 9 || noteCount % 16 == 10 || noteCount % 16 == 12 || noteCount % 16 == 13 || noteCount % 16 == 15) && (noteCount > 1118 && noteCount < 1182)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 16 == 2 || noteCount % 16 == 3 || noteCount % 16 == 6 || noteCount % 16 == 7 || noteCount % 16 == 9 || noteCount % 16 == 12 || noteCount % 16 == 15 ) && (noteCount > 1182 && noteCount < 1246)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 16 == 0 || noteCount % 16 == 2 || noteCount % 16 == 3 || noteCount % 16 == 4 || noteCount % 16 == 6 || noteCount % 16 == 7 || noteCount % 16 == 8 || noteCount % 16 == 10 || noteCount % 16 == 11 || noteCount % 16 == 12) && (noteCount > 1246 && noteCount < 1310)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if ((noteCount % 16 == 0 || noteCount % 16 == 2 || noteCount % 16 == 4 || noteCount % 16 == 6 || noteCount % 16 == 7 || noteCount % 16 == 8 || noteCount % 16 == 10 || noteCount % 16 == 12 || noteCount % 16 == 13 || noteCount % 16 == 14) && (noteCount > 1310 && noteCount < 1374)) //��Ʈ ����
            {
                longNote.SetActive(false);
                NoteManager.isLong = false;
                NoteCreate();
                isTe = false;
            }
            else if (noteCount >= 1374)
            {
                noteCount = 278;
                isTe = false;
                //currentTime = 0;
                //noteCount++;
            }
        }
    }
    
    void NoteCreate()
    {
        GameObject t_note = Instantiate(note, spawn.position, Quaternion.identity);
        t_note.transform.SetParent(this.transform);
    }

    public void Check()
    {
        isTe = true;
        noteCount++;
        //Debug.Log("�ƾ�");
    }    
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval;

    public float GetIntervalLength(float bpm)
    {
        return 60f / bpm*_steps;
    }

    public void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval) != _lastInterval)
        {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }
    }
}
