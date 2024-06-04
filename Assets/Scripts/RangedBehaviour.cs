using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehaviour : MonoBehaviour
{
    private bool canAttack = true;
    private float cooldown;
    public GameObject projectile;
    private EntityStats es;
    private GameObject playerObject;

    void Start()
    {
        es = GetComponent<EntityStats>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()   
    {
        if(canAttack){
            GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);

            projectileInstance.GetComponent<ProjectileDamage>().projectileDamage = es.attackDamage;
            projectileInstance.GetComponent<ProjectileDamage>().projectileLifeSpan = es.attackLifeSpan;

            Vector2 projectileDirection = playerObject.transform.position - transform.position;
            projectileDirection.Normalize();

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(projectileDirection * es.attackRange, ForceMode2D.Impulse);

            canAttack = false;
            cooldown = 0;   
        }

        Cooldown();
    }

    void Cooldown()
    {
        if(cooldown > es.attackSpeed && !canAttack){
            canAttack = true;
        } else {
            cooldown += Time.deltaTime;
        }
    }
}
