using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AUDIO SOURCE")]
    [SerializeField] AudioSource BGMSource;
    [SerializeField] AudioSource SFXSource;

    [Header("AUDIO CLIP")]
    public AudioClip BGM;
    public AudioClip Death;
    public AudioClip Jump;
    public AudioClip StoneBreaking;
    public AudioClip Boing;
    public AudioClip Warning;
    public AudioClip Bite;
    public AudioClip Goose;
    public AudioClip Win;

    private void Start() {
        BGMSource.clip = BGM;
        BGMSource.Play();
    }

    public void PlayBGM(){
        BGMSource.Play();
    }

    public void StopBGM(){
        BGMSource.Pause();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
