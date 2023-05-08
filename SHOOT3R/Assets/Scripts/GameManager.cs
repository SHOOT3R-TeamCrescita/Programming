using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameover;
    [SerializeField]
    GameObject cleared;
    [SerializeField]
    GameObject failed;
    [SerializeField]
    GameObject restart;


    public GameObject Player;
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        NoteManager.noteCombo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<playerHP>().PLhp < 0)
        {
            Time.timeScale = 0;
            gameover.SetActive(true);
            failed.SetActive(true);
            restart.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else if (Boss.GetComponent<BossHP>().BShp < 0)
        {
            Time.timeScale = 0;
            gameover.SetActive(true);
            cleared.SetActive(true);
            restart.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Restart()
    {
        gameover.SetActive(false);
        cleared.SetActive(false);
        failed.SetActive(false);
        restart.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
