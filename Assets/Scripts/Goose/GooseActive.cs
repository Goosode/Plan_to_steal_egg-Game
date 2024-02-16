using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseActive : MonoBehaviour
{
    public Transform gooseSpawn;

    GiantGoose giantGoose;

    void Start() {
        giantGoose = GameObject.FindGameObjectWithTag("Spike").GetComponent<GiantGoose>();
    }

    private void OnTriggerEnter2D(Collider2D checkpoint) {
        if(checkpoint.gameObject.CompareTag("Player")){
            giantGoose.CheckpointUpdate(gooseSpawn.position);
        }
    }
}
