using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float projectileDamage;

    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponent<EntityStats>().hp -= projectileDamage;
            Destroy(this.gameObject);
        }
    }
}
