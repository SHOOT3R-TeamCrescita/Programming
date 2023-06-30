using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static float PLcurHP;
    public static int curNoteCombo;
    public static int Contuinue;
    public static float score = 0;
    public static float TotalScore = 0;
    public static string Name;
    public static float Timer = 0;
    public static float CheckTimer;

    public static float HighScore; //공모전 임시

    private void Awake()
    {
        var obj = FindObjectsOfType<StatManager>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Contuinue = 3;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
