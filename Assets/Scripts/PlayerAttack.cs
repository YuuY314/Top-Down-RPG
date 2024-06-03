using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float cooldown;
    private bool canAttack = true;
    public GameObject projectile;
    private EntityStats es;

    void Start()
    {
        es = GetComponent<EntityStats>();
    }

    void Update()   
    {
        if(Input.GetMouseButton(0) && canAttack){
            GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);

            projectileInstance.GetComponent<ProjectileDamage>().projectileDamage = es.attackDamage;

            Vector2 projectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            projectileDirection.Normalize();

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(projectileDirection * 10, ForceMode2D.Impulse);

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
