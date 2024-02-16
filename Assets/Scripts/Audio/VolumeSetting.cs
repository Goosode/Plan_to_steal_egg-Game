using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start() {
        if(PlayerPrefs.HasKey("musicVolume")){
            LoadVolume();
        }

        if(PlayerPrefs.HasKey("sfxVolume")){
            LoadVolume();
        }
        if(PlayerPrefs.HasKey("masterVolume")){
            LoadVolume();
        }
        else{
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    //Master
    public void SetMasterVolume(){
        float volume = masterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    //Music
    public void SetMusicVolume(){
        float volume = musicSlider.value;
        mixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    //SFX
    public void SetSFXVolume(){
        float volume = sfxSlider.value;
        mixer.SetFloat("Sound", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void LoadVolume(){
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }
}
