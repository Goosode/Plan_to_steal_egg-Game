using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCreditsScene : MonoBehaviour
{
    private void Update() {
        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene(0);
        }

        StartCoroutine(timeToExit());
    }
    IEnumerator timeToExit(){
        yield return new WaitForSeconds(26);
        SceneManager.LoadScene(0);
    }
}
