using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake() {
        int unlockLevel = PlayerPrefs.GetInt("UnlockedLevel", 0);
        //Lock level
        for (int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = false;
        }
        
        //Unlock level
        for(int i = 0; i < unlockLevel; i++){
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int levelId){
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}
