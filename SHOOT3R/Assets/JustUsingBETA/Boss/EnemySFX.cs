using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    public GameObject bulletS;
    //public static bool isDamage = false;

    //public AudioSource[] hit;

    //private int hitIndex;

    public SFX_Player SFXPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SFXPlayer.GetComponents<SFX_Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            PlayRandomSound();
            //this.gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.7f, 0.1f);

            //if (isDamage == true)
            //{
            //  this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            // isDamage = false;
            //}
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.layer == 8)
        //this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void PlayRandomSound()
    {
        SFXPlayer.SfxPlay(SFX_Player.Sfx.hit);
        // ����� ȿ���� ��ȣ�� �����ϰ� ����
        //hitIndex = Random.Range(0, hit.Length);

        // ������ ȿ������ ���
        //hit[hitIndex].Play();
    }
}
