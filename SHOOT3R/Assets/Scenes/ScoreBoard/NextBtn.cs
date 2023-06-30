using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NextBtn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Rank1;
    void Update()
    {
        AnyPress();
        Rank1.text = StatManager.Name.ToString();
    }
    void AnyPress()
    {
        if (Input.anyKey || Input.GetMouseButton(0))
        {
            Loading.LoadScene(0, 1.5f);
        }
    }

    
}
