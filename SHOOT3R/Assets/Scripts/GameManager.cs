using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] GameObject gameover;
    //[SerializeField] GameObject cleared;

    //컨티뉴
    [SerializeField] GameObject failedAni;
    [SerializeField] GameObject ContinueUI;
    //[SerializeField] GameObject restart;
    [SerializeField] Image[] life;

    //클리어
    [SerializeField] GameObject clearedAni;

    [SerializeField] GameObject noteCreater;

    //일시정지
    [SerializeField] GameObject Pause;

    [SerializeField] GameObject SettingUI;

    //컷씬
    [SerializeField] GameObject CutScene;
    [SerializeField] GameObject MainUI; //전체 UI

    public GameObject Player;
    public GameObject Boss;

    public static int towercount;

    public static bool isStop = false;

    bool justCheck = true;

    public static float stoptime;

    [SerializeField] AudioSource Click;

    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Tutorial") == null)
        {
            isStop = false;
            towercount = 0;
            stoptime = 1;
            Time.timeScale = 1;
            NoteManager.noteCombo = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<playerHP>().PLhp <= 0 && !CutSceneMove.isEnd)
        {
            isStop = true;
            Time.timeScale = stoptime;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (justCheck)
            {
                StartCoroutine("StopCO");
                Player.GetComponent<playerMove>().anim.SetTrigger("isDie");
                justCheck = false;
                noteCreater.GetComponent<NoteCreater>().music.Pause();
                failedAni.SetActive(true);
            }
        }

        else if (Boss.GetComponent<BossHP>().BShp <= 0)
        {
            isStop = true;
            Time.timeScale = stoptime;
            if (justCheck)
            {
                StartCoroutine("StopCO");
                justCheck = false;
                clearedAni.SetActive(true);
            }
        }

        if (towercount == 3)
        {
            Save();
            CutScene.SetActive(true);
            MainUI.SetActive(false);
            towercount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isStop)
            {
                Pause.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
                noteCreater.GetComponent<NoteCreater>().music.Pause();
                isStop = true;
            }
        }

        CheckLife();

        StatManager.Timer += Time.deltaTime;
        //Debug.Log(StatManager.Timer);
    }

    public void Continue()
    {
        Click.Play();
        noteCreater.GetComponent<NoteCreater>().music.Play();
        isStop = false;
        Pause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Click.Play();
        Init();
        //life[StatManager.Contuinue].color = new Color(1, 0, 0, 1);
        isStop = false;
        Loading.LoadScene(0,3.0f);
    }

    public void Setting()
    {
        Click.Play();
        SettingUI.SetActive(true);
    }

    public void SettingExit()
    {
        Click.Play();
        SettingUI.SetActive(false);
    }

    public void ExittoScore()
    {
        Click.Play();
        Init();
        //life[StatManager.Contuinue].color = new Color(1, 0, 0, 1);
        isStop = false;
        Loading.LoadScene(0, 3.0f);
    }

    /*public void Restart()
    {
        gameover.SetActive(false);
        cleared.SetActive(false);
        //failed.SetActive(false);
        restart.SetActive(false);
        StatManager.PLcurHP = Player.GetComponent<playerHP>().MaxHP;
        StatManager.curNoteCombo = 0;
        Loading.LoadScene(2, 3.0f);
    }*/

    public void Retry()
    {
        StatManager.Contuinue--;
        isStop = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CheckStage();
    }

    void CheckStage()
    {
        switch(noteCreater.GetComponent<NoteCreater>().stageCheck)
        {
            case 1f:
                Loading.LoadScene(1, 1.5f);
                break;
            case 1.5f:
                Loading.LoadScene(1, 1.5f);
                break;
            default:
                Debug.Log("체크!");
                break;
        }
    }

    void CheckLife()
    {
        if(StatManager.Contuinue==2)
        {
            life[2].color = new Color(0, 0, 0, 0);
        }
        else if (StatManager.Contuinue ==1)
        {
            life[2].color = new Color(0, 0, 0, 0);
            life[1].color = new Color(0, 0, 0, 0);
        }
        else if (StatManager.Contuinue == 0)
        {
            life[2].color = new Color(0, 0, 0, 0);
            life[1].color = new Color(0, 0, 0, 0);
            life[0].color = new Color(0, 0, 0, 0);
        }
    }

    private IEnumerator StopCO()
    {
        stoptime = 0.8f;
        while (stoptime >= 0f)
        {
            stoptime -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        if (stoptime < 0)
            stoptime = 0;
    }

    void Save()
    {
        StatManager.PLcurHP = Player.GetComponent<playerHP>().PLhp;
        StatManager.curNoteCombo = NoteManager.noteCombo;
    }

    void Init()
    {
        StatManager.Contuinue = 3;
        StatManager.PLcurHP = Player.GetComponent<playerHP>().MaxHP;
        StatManager.curNoteCombo = 0;
        StatManager.score = 0;
        StatManager.Timer = 0;
        StatManager.CheckTimer = 0;
    }
}
