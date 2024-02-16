using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoose : MonoBehaviour
{
    GiantGoose giantGoose;
    AudioManager audioManager;

    private void Start() {
        giantGoose = GameObject.FindGameObjectWithTag("Spike").GetComponent<GiantGoose>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Player") &&  giantGoose.spawned == false){
            giantGoose.ChP();
            giantGoose.Spawn(true);
            giantGoose.ItSpawned(true);
            audioManager.PlaySFX(audioManager.Goose);
        }
    }
}
