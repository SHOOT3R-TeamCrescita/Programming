using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
    public AudioMixer mainAudio;

    public Slider BGM;
    public Slider SFX;

    public void SetBGM()
    {
        mainAudio.SetFloat("BGMpara", Mathf.Log10(BGM.value) * 20);
    }

    public void SetSFX()
    {
        mainAudio.SetFloat("SFXpara", Mathf.Log10(SFX.value) * 20);
    }

}
