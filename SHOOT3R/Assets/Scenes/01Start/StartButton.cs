using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject AP;
    [SerializeField] GameObject Setting;


    private void Update()
    {
        AnyPress();
    }
    public void Sstart()
    {
        SceneManager.LoadScene(1);
    }

    void AnyPress()
    {
        if (Input.anyKey || Input.GetMouseButton(0))
        {
            menu.SetActive(true);
            Destroy(AP);
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
}
