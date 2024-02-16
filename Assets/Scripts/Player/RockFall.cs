using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    public int count{get; private set;}
    public bool falled {get; set;}
    public bool isFall {get; private set;}
    public GameManagerScripts gameManager; 

    Vector2 checkpointPos;
    Rigidbody2D rb;
    Animator animator;
    PlayerDead playerDead;
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    void Start()
    {
        playerDead = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDead>();
        checkpointPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void Update() {
        if(isFall == true){

            //press R to respawn
            if(Input.GetKey(KeyCode.R) && falled == true){
                gameManager.Gameover(false);
                transform.position = checkpointPos;
                Fall(false);
                rb.velocity = new Vector2(0, 0);
                animator.SetBool("isCrack", false);
                falled = false;

                count += 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D rock) {
        if(rock.gameObject.CompareTag("Ground")){
            Fall(true);
            playerDead.Die();

            StartCoroutine(Falling(0.38f));
        }
    }

    public void Fall(bool fall){
        isFall = fall;
    }
    
    //Checkpoint update
    public void CheckpointUpdate(Vector2 pos){
        checkpointPos = pos;
    }

    //Use when stone falled
    IEnumerator Falling(float duration){
        animator.SetBool("isCrack", true);
        audioManager.PlaySFX(audioManager.StoneBreaking);
        gameManager.Gameover(true);
        yield return new WaitForSeconds(duration);
        falled = true;
    }
}
