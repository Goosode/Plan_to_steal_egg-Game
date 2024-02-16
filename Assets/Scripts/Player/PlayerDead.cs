using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    Vector2 checkpointPos;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    RockFall rockFall;
    PlayerControll playerControll;
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        playerControll = GetComponent<PlayerControll>();
        rockFall = GameObject.FindGameObjectWithTag("Rock").GetComponent<RockFall>();

        checkpointPos = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update() {
        if(rb.simulated == false){

            //press R to respawn
            if(Input.GetKey(KeyCode.R) && rockFall.falled == true){
                transform.position = checkpointPos;
                rb.simulated = true;
                rb.velocity = new Vector2(0, 0);
                spriteRenderer.enabled = true;
                playerControll.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D player) {
        if(player.gameObject.CompareTag("Spike")){
            Die();
            rockFall.Fall(true);
            
        
            StartCoroutine(AnimationDead(0.38f));
        }
    }

    //Use when player die
    public void Die(){
        rb.simulated = false;
        playerControll.enabled = false;
    }

    //Checkpoint update
    public void CheckpointUpdate(Vector2 pos){
        checkpointPos = pos;
    }

    //Play died animation
    IEnumerator AnimationDead(float duration){
        animator.SetTrigger("isDead");
        audioManager.PlaySFX(audioManager.Death);
        yield return new WaitForSeconds(duration);
        spriteRenderer.enabled = false;
    }

}
