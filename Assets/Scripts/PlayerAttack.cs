using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float cooldown;
    private bool canAttack = true;
    public GameObject projectile;
    private EntityStats es;
    public AudioClip weaponAudioClip;
    public float audioPitch;
    public AudioSource weaponSound;

    void Start()
    {
        es = GetComponent<EntityStats>();
    }

    void Update()   
    {
        if(Input.GetMouseButton(0) && canAttack){
            GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);

            projectileInstance.GetComponent<ProjectileDamage>().projectileDamage = es.attackDamage * ((es.bonusAttackDamage + 100) / 100);
            projectileInstance.GetComponent<ProjectileDamage>().projectileLifeSpan = es.attackLifeSpan;

            Vector2 projectileDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            projectileDirection.Normalize();

            float rotationZ = Mathf.Atan2(projectileDirection.y, projectileDirection.x) * Mathf.Rad2Deg;
            projectileInstance.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(projectileDirection * es.attackRange, ForceMode2D.Impulse);

            weaponSound.pitch = audioPitch;
            weaponSound.PlayOneShot(weaponAudioClip);

            canAttack = false;
            cooldown = 0;   
        }

        Cooldown();

        if(Input.GetKeyDown(KeyCode.G)){
            InventoryManager.Instance.DiscardWeapon();
        }
    }

    void Cooldown()
    {
        if(cooldown > (es.attackSpeed * ((100 - es.bonusAttackSpeed) / 100)) && !canAttack){
            canAttack = true;
        } else {
            cooldown += Time.deltaTime;
        }
    }
}
