using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItems : MonoBehaviour
{
    public GameObject[] weapons = new GameObject[6];
    public int item;
    public string equippedWeapon = PlayerAccount.currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        CheckWeapon();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CheckWeapon()
    {
        equippedWeapon = PlayerAccount.currentWeapon;
        switch (equippedWeapon)
        {
            case "Bakunawa (Worn)":
                Debug.Log("equipped update" + PlayerAccount.currentWeapon);
                item = 0;
                break;

            case "Bakunawa (Fine)":
                Debug.Log("equipped update" + PlayerAccount.currentWeapon);
                item = 1;
                break;
            case "Panabas (Worn)":
                Debug.Log("equipped update" + PlayerAccount.currentWeapon);
                item = 2;
                break;
            case "Lihok (Worn)":
                Debug.Log("equipped update" + PlayerAccount.currentWeapon);
                item = 3;
                break;
            case "Candy Cane":
                Debug.Log("equipped update" + PlayerAccount.currentWeapon);
                item = 4;
                break;
            case "Walking Axe":
                Debug.Log("equipped update" + PlayerAccount.currentWeapon);
                item = 5;
                break;
            default:
                item = 0;
                break;
        }
        switchWeapons(item);
    }

    public void switchWeapons(int item)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);

        }
        weapons[item].SetActive(true);
    }
}
