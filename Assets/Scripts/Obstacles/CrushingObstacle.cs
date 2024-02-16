using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingObstacle : MonoBehaviour
{
    private float upSpeed = 1.2f;
    private float downSpeed = 20f;
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;
    
    bool posUp;

    Animator animator;
    
    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(transform.position.y >= up.position.y){
            posUp = true;
        }
        if(transform.position.y <= down.position.y){
            posUp = false;
        }

        if(posUp){
            transform.position = Vector2.MoveTowards(transform.position, down.position, downSpeed * Time.deltaTime);  
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, up.position, upSpeed * Time.deltaTime);
            StartCoroutine(WaitToCrush());
        }
    }

    private IEnumerator WaitToCrush(){
        downSpeed = 0f;
        yield return new WaitForSeconds(4f);
        animator.SetBool("isShake", true);
        yield return new WaitForSeconds(2.2f);
        animator.SetBool("isShake", false);
        downSpeed = 20f;
    }
}
