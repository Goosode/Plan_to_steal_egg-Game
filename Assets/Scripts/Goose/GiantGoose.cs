using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantGoose : MonoBehaviour
{
    private float speed = .7f;
    [SerializeField] private Transform Player;
    private bool stop;

    public bool spawned;
    public bool respanwing = false;

    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2D;
    RockFall rockFall;

    private void Start() {
        rockFall = GameObject.FindGameObjectWithTag("Rock").GetComponent<RockFall>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        checkpointPos = transform.position;
    }

    private void Update() {
        if(rockFall.isFall == true){
            respanwing = true;
        }

        //Despawn goose
        if(respanwing == true){
            if(Input.GetKey(KeyCode.R) && rockFall.falled == true){
                Spawn(false);
                ItSpawned(false);
                respanwing = false;
            }
        }


        //Follow target
        if(transform.position.x >= Player.position.x){
            stop = false;
        }

        if(transform.position.x <= Player.position.x){
            stop = true;
        }

        if(stop){
            transform.position = Vector2.MoveTowards(transform.position,Player.position, speed * Time.deltaTime);
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position,Player.position, 0);
        }
    }

    public void ItSpawned(bool SP){
        spawned = SP;
    }

    public void Spawn(bool Spawn){
        spriteRenderer.enabled = Spawn;
        boxCollider2D.enabled = Spawn;
    }

    public void ChP(){
        transform.position = checkpointPos;
    }

    public void CheckpointUpdate(Vector2 pos){
        checkpointPos = pos;
    }
}
