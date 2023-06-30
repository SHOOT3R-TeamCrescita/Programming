using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject AP;
    [SerializeField] Animator anim;
    [SerializeField] GameObject Setting;
    [SerializeField] TextMeshProUGUI HighScore;
    [SerializeField] GameObject Fade;

    AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
        // 하이스코어 초기화
        //StatManager.HighScore = 0;
        //PlayerPrefs.SetFloat("HighScore", StatManager.HighScore);
        StatManager.HighScore = PlayerPrefs.GetFloat("HighScore");
        
    }

    private void Update()
    {
        AnyPress();
        HighScore.text = "HIGH SCORE " + StatManager.HighScore.ToString("F0");
    }
    public void Sstart()
    {
        SceneManager.LoadScene(1);
    }

    void AnyPress()
    {
        if (Input.anyKey || Input.GetMouseButton(0))
        {
            //menu.SetActive(true);
            //Destroy(AP);
            music.Stop();
            Fade.SetActive(true);
            anim.SetTrigger("Click");
        }
    }

    public void OPSetting()
    {
        Setting.SetActive(true);
    }

    public void EDSetting()
    {
        Setting.SetActive(false);
    }

    public void ScoreBoard()
    {
        SceneManager.LoadScene(4);
    }

}
