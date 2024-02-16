using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private float bouncePower = 4.6f;

    Animator animator;
    AudioManager audioManager;
    
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.CompareTag("Player")){
            target.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
            StartCoroutine(Bounce());
        }

        if(target.gameObject.CompareTag("Rock")){
            target.gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.up * 0.33f)+(Vector2.right * 0.05f), ForceMode2D.Impulse);
            StartCoroutine(Bounce());
        }
    }

    private IEnumerator Bounce(){
        animator.SetBool("isBounce", true);
        audioManager.PlaySFX(audioManager.Boing);
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("isBounce", false);
    }
}
