using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStore : MonoBehaviour
{
    public GameObject storeObject;
    public GameObject storeWarning;
    private GameObject playerObject;

    public List<Weapon> weaponsSold;

    public GameObject shopBackground;
    public GameObject shopItem;

    void Start()
    {
        RandomItems();
        storeObject.SetActive(false);
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, playerObject.transform.position);

        if(dist < 2){
            storeWarning.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                storeObject.SetActive(true);
                RandomItems();
            }
        } else {
            storeWarning.SetActive(false);
            storeObject.SetActive(false);
        }
    }

    void RandomItems()
    {
        GameObject[] shopButtons = GameObject.FindGameObjectsWithTag("ShopItem");
        foreach(GameObject go in shopButtons){
            Destroy(go);
        }

        for(int i = 0; i < 3; i++){
            int randomNumber = Random.Range(0, weaponsSold.Count);

            GameObject newShopItem = Instantiate(shopItem, shopBackground.transform);
            newShopItem.GetComponent<ShopItem>().w = weaponsSold[randomNumber];
            newShopItem.GetComponent<ShopItem>().Setup(weaponsSold[randomNumber]);
        }
    }
}
