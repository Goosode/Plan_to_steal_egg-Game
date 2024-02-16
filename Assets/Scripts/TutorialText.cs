using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private GameObject Text1;
    [SerializeField] private GameObject Text2;

    private void OnTriggerEnter2D(Collider2D player) {
        if(player.gameObject.CompareTag("Player")){
            Text1.SetActive(false);
            Text2.SetActive(false);
        }
    }
}
