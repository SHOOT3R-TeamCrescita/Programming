using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static float PLcurHP;

    private void Awake()
    {
        var obj = FindObjectsOfType<StatManager>();
        if (obj.Length == 1)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
