using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Weapon w;
    public Text itemNameHolder;
    public Text itemValueHolder;
    public Image itemIconHolder;
    public Text itemInfoHolder;

    public Button shopButton;

    void Start()
    {
        Setup(w);
    }

    void Update()
    {
        
    }

    public void Setup(Weapon w)
    {
        itemNameHolder.text = w.weaponName;
        itemValueHolder.text = w.weaponValue.ToString();
        itemIconHolder.sprite = w.weaponIcon;
        itemInfoHolder.text = "Attack Damage: " + w.weaponDamage.ToString() + "\nAttack Speed: " + w.weaponSpeed.ToString() + "\nRange: " + w.weaponRange.ToString();

        if(InventoryManager.Instance.goldCoins < w.weaponValue){
            shopButton.interactable = false;
        } else {
            shopButton.interactable = true;
        }
    }

    public void BuyWeapon()
    {
        if(InventoryManager.Instance.inventory[4] != null){

        } else {
            for(int i = 0; i < 5; i++){
                if(InventoryManager.Instance.inventory[i] == null){
                    InventoryManager.Instance.inventory[i] = w;
                    break;
                }
            }

            InventoryManager.Instance.AddGold(w.weaponValue * -1);
            RefreshShop();
            Destroy(this.gameObject);
        }
    }

    void RefreshShop()
    {
        GameObject[] shopButtons = GameObject.FindGameObjectsWithTag("ShopItem");
        foreach(GameObject go in shopButtons){
            go.GetComponent<ShopItem>().Setup(go.GetComponent<ShopItem>().w);
        }
    }
}
