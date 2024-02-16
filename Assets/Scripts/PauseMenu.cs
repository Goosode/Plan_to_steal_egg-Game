using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseUI;
    public GameObject settingUI;

    private int currentSceneIndex;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPause){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseUI.SetActive(false);
        settingUI.SetActive(false);
        audioManager.PlayBGM();
        
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    public void Pause(){
        pauseUI.SetActive(true);
        audioManager.StopBGM();

        Time.timeScale = 0f;
        gameIsPause = true;
    }
    
    public void MainMenu(){
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);

        Time.timeScale = 1f;
        gameIsPause = false;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
        gameIsPause = false;
    }

    private void OnApplicationQuit() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
    }
}
