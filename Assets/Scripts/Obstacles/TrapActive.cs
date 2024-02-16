using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActive : MonoBehaviour
{
    Animator animator;
    AudioManager audioManager;
    
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Player")){
            StartCoroutine(Active());
        }
    }

    private IEnumerator Active(){
        animator.SetBool("isWarning", true);
        audioManager.PlaySFX(audioManager.Warning);

        yield return new WaitForSeconds(0.6f);
        animator.SetBool("isBite", true);
        audioManager.PlaySFX(audioManager.Bite);

        yield return new WaitForSeconds(0.6f);
        animator.SetBool("isBite", false);

        yield return new WaitForSeconds(0.6f);
        animator.SetBool("isWarning", false);
    }
}
