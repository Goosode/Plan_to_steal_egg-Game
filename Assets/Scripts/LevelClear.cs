using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour
{
    public GameManagerScripts gameManager;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D player) {
        if(player.gameObject.CompareTag("Player")){
            gameManager.GameWin(true);
            UnlockNewLevel();
            
            audioManager.StopBGM();
            audioManager.PlaySFX(audioManager.Win);

            Time.timeScale = 0f;
        }
    }

    private void UnlockNewLevel(){
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex")){
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
