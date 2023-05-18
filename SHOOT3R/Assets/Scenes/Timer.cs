using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("False", 0.3f);
        Invoke("True", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void False()
    {
        gameObject.SetActive(false);
    }
    void True()
    {
        gameObject.SetActive(true);
    }
}
