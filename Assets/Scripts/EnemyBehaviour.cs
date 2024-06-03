using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehauvior : MonoBehaviour
{
    private float enemySpeed;
    private GameObject playerObject;
    private EntityStats es;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        es = GetComponent<EntityStats>();
        enemySpeed = es.baseSpeed;
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, enemySpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            collision.gameObject.GetComponent<EntityStats>().hp -= es.attackDamage;
            es.hp -= es.maxHp + 1;
        }
    }
}
