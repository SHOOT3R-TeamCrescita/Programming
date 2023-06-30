using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Combo;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI TotalScore;
    [SerializeField] TextMeshProUGUI Timer;

    float totalscore; //공모전 임시 점수
    float timescore;
    [SerializeField] TextMeshProUGUI HighScore;
    [SerializeField] GameObject[] Rank;

    void Start()
    {
        StatManager.HighScore = PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        HighScore.text = "HIGH SCORE " + StatManager.HighScore.ToString("F0");
        timescore = 600 - StatManager.CheckTimer;
        if (timescore < 3)
            timescore = 3;

        totalscore = ((NoteManager.noteCombo+1) * StatManager.score * timescore) / 10000;
        if(totalscore > StatManager.HighScore)
        {
            StatManager.HighScore = totalscore;
            PlayerPrefs.SetFloat("HighScore", StatManager.HighScore);
        }

        Combo.text = NoteManager.noteCombo.ToString("F0");
        Score.text = StatManager.score.ToString("F0");
        //TotalScore.text = StatManager.TotalScore.ToString("F0");
        TotalScore.text = totalscore.ToString("F0");
        //Timer.text = StatManager.CheckTimer.ToString("F0");
        Timer.text = (StatManager.CheckTimer / 60).ToString("F0") + "분" + (StatManager.CheckTimer % 60).ToString("F0") + "초";

        if(totalscore >= 150000)
            Rank[0].SetActive(true);
        else if (totalscore < 150000 && totalscore > 100000)
            Rank[1].SetActive(true);
        else if (totalscore < 100000 && totalscore > 50000)
            Rank[2].SetActive(true);
        else if (totalscore < 50000)
            Rank[3].SetActive(true);
    }
}
