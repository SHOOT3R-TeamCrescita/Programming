using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Player : MonoBehaviour
{
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { hit, kick, shoot, jump, dash, miss };
    int sfxCursor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SfxPlay(Sfx type)
    {
        switch (type)
        {
            case Sfx.hit:
                sfxPlayer[sfxCursor].clip = sfxClip[Random.Range(0, 2)];
                break;
            case Sfx.kick:
                sfxPlayer[sfxCursor].clip = sfxClip[Random.Range(0, 2)];
                break;
            case Sfx.shoot:
                sfxPlayer[sfxCursor].clip = sfxClip[2];
                break;
            case Sfx.jump:
                sfxPlayer[sfxCursor].clip = sfxClip[3];
                break;
            case Sfx.dash:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
                break;
            case Sfx.miss:
                sfxPlayer[sfxCursor].clip = sfxClip[5];
                break;

        }

        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }
}
