using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerItem : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            GetComponent<playerMove>().SFXPlayer.SfxPlay(SFX_Player.Sfx.item);
            bool isKit1 = other.gameObject.name.Contains("Kit1");

            if(isKit1)
            {
                GetComponent<playerHP>().PLhp += 20;
            }
        }
    }
}
