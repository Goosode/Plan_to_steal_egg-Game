using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float maxWalkSpeed = 1;
    [SerializeField] private float jumpPower = 3;
    private float moveX;
    [SerializeField] private LayerMask groundLayer;

    AudioManager audioManager;
    
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider2D;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    
    void Update()
    {
        //Movement
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * maxWalkSpeed, rb.velocity.y);
    
        //Jump
        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            audioManager.PlaySFX(audioManager.Jump);
        }
        
        Animation();
    }

    //Animator method
    private void Animation(){
        if(moveX > 0f){
            animator.SetBool("isMoving", true);
            spriteRenderer.flipX = false;
        }
        else if(moveX < 0f){
            animator.SetBool("isMoving", true);
            spriteRenderer.flipX = true;
        }
        else{
            animator.SetBool("isMoving", false);
        }
    }

    //Ground check
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}
