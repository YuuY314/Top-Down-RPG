using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D rb;
    private EntityStats es;
    private Animator anim;
    public AudioSource footstepsSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        es = GetComponent<EntityStats>();
        anim = GetComponent<Animator>();
        moveSpeed = es.baseSpeed;
    }

    void FixedUpdate()
    {
        WASDMove();
    }

    void WASDMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        rb.AddForce(new Vector2(horizontal * moveSpeed * Time.deltaTime, vertical * moveSpeed * Time.deltaTime));

        //Movimento diagonal
        if((horizontal > 0 || horizontal < 0) && (vertical > 0 || vertical < 0)){
            moveSpeed = es.baseSpeed * 0.66f;
        } else {
            moveSpeed = es.baseSpeed;
        }

        //Animação
        if(horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0){
            if(horizontal < 0){
                GetComponent<SpriteRenderer>().flipX = true;
            } else {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            
            anim.Play("Move");
            footstepsSound.volume = 0.5f * OptionsManager.Instance.audioSlider.value;
        } else {
            anim.Play("Idle");
            footstepsSound.volume = 0;
        }
    }
}
