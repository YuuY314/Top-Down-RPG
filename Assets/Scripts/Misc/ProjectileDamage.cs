using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float projectileDamage;
    public float projectileLifeSpan = 1;
    public bool isEnemy;

    void Start()
    {
        Destroy(this.gameObject, projectileLifeSpan);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "Enemy" && isEnemy) || (collision.gameObject.tag == "Player" && !isEnemy)){
            collision.gameObject.GetComponent<EntityStats>().RemoveHp(projectileDamage);
            Destroy(this.gameObject);
        } else if(collision.gameObject.tag == "Wall"){
            Destroy(this.gameObject);
        }
    }
}
