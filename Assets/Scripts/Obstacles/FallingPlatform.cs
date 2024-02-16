using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1.2f;
    private float respawnTime = 2f;

    Vector2 defaultPos;
    Rigidbody2D rb;
    Animator animator;

    private void Start() {
        defaultPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D player) {
        if(player.gameObject.CompareTag("Player")){
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall(){
        animator.SetBool("isPortShake", true);
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool("isPortShake", false);
        yield return new WaitForSeconds(respawnTime);
        Reset();
    }

    private void Reset() {
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = defaultPos;
    }
}
