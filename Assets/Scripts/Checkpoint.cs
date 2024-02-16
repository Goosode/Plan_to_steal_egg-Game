using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform respawnPoint;
    public Transform respawnRock;

    PlayerDead playerDead;
    RockFall rockFall;
    Collider2D coll2D;

    void Start()
    {
        rockFall = GameObject.FindGameObjectWithTag("Rock").GetComponent<RockFall>();
        playerDead = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDead>();
        coll2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D checkpoint) {
        if(checkpoint.gameObject.CompareTag("Player")){
            //update checkpoint
            playerDead.CheckpointUpdate(respawnPoint.position);
            rockFall.CheckpointUpdate(respawnRock.position);

            //Unable to use old checkpoints when pass again
            coll2D.enabled = false;
        }
    }
}
