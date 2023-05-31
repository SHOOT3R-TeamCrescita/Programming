using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField]
    GameObject ConUI;
    [SerializeField]
    GameObject GOUI;
    [SerializeField]
    GameObject Fade;

    public void Open()
    {
        Fade.SetActive(true);
    }

    public void UIOpen()
    {
        if (StatManager.Contuinue > 0)
            ConUI.SetActive(true);
        else
            GOUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OBDestory()
    {
        Destroy(gameObject);
    }
}
