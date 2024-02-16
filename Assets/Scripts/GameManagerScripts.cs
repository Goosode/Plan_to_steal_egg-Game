using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScripts : MonoBehaviour
{   
    public GameObject gameOverUI;
    public GameObject levelClearUI;


    public void Gameover(bool TF){
        gameOverUI.SetActive(TF);
    }

    public void GameWin(bool TF){
        levelClearUI.SetActive(TF);
    }
}
