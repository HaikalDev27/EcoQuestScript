using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMasterVolume (float volume){
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetSfxVolume (float volume){
        audioMixer.SetFloat("sfxVolume", volume);
    }

    public void SetMusicVolume (float volume){
        audioMixer.SetFloat("musicVolume", volume);
    }

    public void SetQuality (int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
