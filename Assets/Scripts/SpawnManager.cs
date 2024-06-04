using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject door;
    public List<GameObject> spawnPoints;
    public List<GameObject> enemies;
    public int enemiesAlive = 0;
    private bool isDungeonActive = false;

    void Start()
    {
        
    }

    void Update()
    {
        CheckDungeonEnd();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            door.SetActive(true);
            SpawnEnemies();
            GetComponent<BoxCollider2D>().enabled = false;
            isDungeonActive = true;
        }    
    }

    void SpawnEnemies()
    {
        foreach(GameObject sp in spawnPoints){
            int randomEnemy = Random.Range(0, 2);
            GameObject newEnemy = Instantiate(enemies[randomEnemy], sp.transform.position, Quaternion.identity);
            newEnemy.GetComponent<EntityStats>().spawnManager = this;
            enemiesAlive++;
        }
    }

    void CheckDungeonEnd()
    {
        if(isDungeonActive){
            if(enemiesAlive == 0){
                door.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
