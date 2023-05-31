using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static float PLcurHP;
    public static int curNoteCombo;
    public static int Contuinue;

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
