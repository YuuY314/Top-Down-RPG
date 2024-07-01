using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EntityStats : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public float baseSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float attackLifeSpan;
    public float attackRange;
    public int goldCarry;
    
    //Apenas inimigos
    public SpawnManager spawnManager;

    //Apenas jogador
    public int level = 1;
    public int exp = 0;
    public float bonusAttackDamage;
    public float bonusAttackSpeed;

    //Particles
    public GameObject deathParticles;

    //Audio
    private AudioSource hitAudio;

    void Start()
    {
        hp = maxHp;
        hitAudio = GameObject.Find("Hit Sound").GetComponent<AudioSource>();
    }

    void Update()
    {
        DamageBlink();
    }

    public void Death()
    {
        if(hp <= 0){
            if(this.gameObject.tag != "Player"){
                InventoryManager.Instance.AddGold(goldCarry);
                GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>().AddExp(exp);
            }

            //Computa a morte do inimigo
            if(this.gameObject.tag == "Enemy"){
                spawnManager.enemiesAlive--;
            }

            hitAudio.volume = 0.5f * OptionsManager.Instance.audioSlider.value;

            Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    public void RemoveHp(float hpToRemove)
    {
        GameObject newPopUp = Instantiate(HUDManager.Instance.damagePopUp, this.gameObject.transform.position, Quaternion.identity);
        newPopUp.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2f, 2f), 5), ForceMode2D.Impulse);
        newPopUp.GetComponentInChildren<Text>().text = (Mathf.RoundToInt(hpToRemove * 10)).ToString();
        Destroy(newPopUp, 1);

        //Change color
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        hitAudio.volume = 0.2f * OptionsManager.Instance.audioSlider.value;

        hp -= hpToRemove;
        Death();

        hitAudio.Play();
    }

    void AddExp(int expToAdd)
    {
        exp += expToAdd;
        if(exp >= level * 100) {
            exp = 0;
            level++;
            HUDManager.Instance.SetupLevelUp();
        }
    }

    void DamageBlink()
    {
        if(gameObject.GetComponent<SpriteRenderer>().color != Color.white){
            gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(gameObject.GetComponent<SpriteRenderer>().color, Color.white, 10 * Time.deltaTime);
        }
    }
}
