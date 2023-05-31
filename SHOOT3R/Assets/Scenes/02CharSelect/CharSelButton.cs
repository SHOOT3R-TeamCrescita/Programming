using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharSelButton : MonoBehaviour
{
    [SerializeField] GameObject Noa;
    [SerializeField] GameObject Reo;
    [SerializeField] GameObject Kiara;
    [SerializeField] GameObject Name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CLNoah()
    {
        Noa.SetActive(true);
        Reo.SetActive(false);
        Kiara.SetActive(false);
    }

    public void CLReo()
    {
        Noa.SetActive(false);
        Reo.SetActive(true);
        Kiara.SetActive(false);
    }

    public void CLKiara()
    {
        Noa.SetActive(false);
        Reo.SetActive(false);
        Kiara.SetActive(true);
    }

    public void SelectBtn()
    {
        Loading.LoadScene(2,3.0f);
    }

    public void NameSet()
    {
        Name.SetActive(false);
    }
}