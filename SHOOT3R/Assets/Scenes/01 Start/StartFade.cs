using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour
{
    public void NextFade()
    {
        Loading.LoadScene(1, 3.0f);
    }
}
