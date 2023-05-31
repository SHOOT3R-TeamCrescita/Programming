using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUICL : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject MainUI;
    [SerializeField] GameObject ClearObj;

    // Start is called before the first frame update
    public void ClearScene()
    {
        GameManager.stoptime = 1.0f;
        MainUI.SetActive(false);
        Player.SetActive(false);
        Boss.SetActive(false);
        ClearObj.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DestUI()
    {
        Destroy(gameObject);
    }    
}
