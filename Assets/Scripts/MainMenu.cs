using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu button")]
    [SerializeField] private Button newGame;

    public void NewGame(){
        PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 0) + 1);
        PlayerPrefs.Save();
        DisableMenuButton();
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    private void DisableMenuButton(){
        newGame.interactable = false;
    }
}
