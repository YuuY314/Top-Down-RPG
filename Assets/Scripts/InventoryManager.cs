using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    public GameObject invBackground;
    public GameObject invSlot;
    public List<Weapon> inventory;
    public int activeSlot;
    private int selectedSlot = 0;
    private EntityStats playerStats;

    public int goldCoins;
    public Text goldText;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        SelectWeapon(1);
    }

    void Update()
    {
        InventorySelection();
    }

    void RefreshInventory()
    {
        goldText.text = goldCoins.ToString();

        GameObject[] destroySlots = GameObject.FindGameObjectsWithTag("Slot");
        foreach(GameObject go in destroySlots){
            Destroy(go);
        }

        int hotkey = 1;

        foreach(Weapon w in inventory){
            GameObject slotInstance = Instantiate(invSlot, invBackground.transform);

            Image[] slotIcons = slotInstance.GetComponentsInChildren<Image>();

            if(w == null){
                slotIcons[1].GetComponent<Image>().enabled = false;
            } else {
                slotInstance.GetComponentInChildren<Image>().enabled = true;

                slotIcons[1].GetComponent<Image>().sprite = w.weaponIcon;

                // Indicativo de seleção de arma
                slotIcons[0].GetComponent<Image>().color = Color.white;
                if(selectedSlot == hotkey){
                    slotIcons[0].GetComponent<Image>().color = Color.yellow;
                }
            }

            slotInstance.GetComponentInChildren<Text>().text = hotkey.ToString();
            hotkey++;
        }
    }

    void SelectWeapon(int hotkey)
    {
        Weapon selectedWeapon = inventory[hotkey - 1];
        activeSlot = hotkey - 1;

        playerStats.attackDamage = selectedWeapon.weaponDamage;
        playerStats.attackSpeed = selectedWeapon.weaponSpeed;
        playerStats.attackRange = selectedWeapon.weaponRange;
        playerStats.attackLifeSpan = selectedWeapon.weaponLifeSpan;
        playerStats.gameObject.GetComponent<PlayerAttack>().projectile = selectedWeapon.weaponProjectile;
        playerStats.gameObject.GetComponent<PlayerAttack>().weaponAudioClip = selectedWeapon.weaponSound;
        playerStats.gameObject.GetComponent<PlayerAttack>().audioPitch = selectedWeapon.weaponSoundPitch;

        selectedSlot = hotkey;
        RefreshInventory();
    }

    void InventorySelection()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SelectWeapon(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SelectWeapon(2);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            SelectWeapon(3);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)){
            SelectWeapon(4);
        }

        if(Input.GetKeyDown(KeyCode.Alpha5)){
            SelectWeapon(5);
        }
    }

    public void AddGold(int g)
    {
        goldCoins += g;
        RefreshInventory();
    }

    public void DiscardWeapon()
    {
        if(activeSlot != 0){
            inventory[activeSlot] = null;
            SelectWeapon(1);
            RefreshInventory();
        }
    }
}
