using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D rb;
    private EntityStats es;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        es = GetComponent<EntityStats>();
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

        if((horizontal > 0 || horizontal < 0) && (vertical > 0 || vertical < 0)){
            moveSpeed = es.baseSpeed * 0.66f;
        } else {
            moveSpeed = es.baseSpeed;
        }
    }
}
