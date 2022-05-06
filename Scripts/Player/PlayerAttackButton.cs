using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackButton : MonoBehaviour
{
    [Header("Weapon Components")]
    WeaponController equippedWeapon;
    public GameObject[] Weapons;

    [SerializeField]
    private string currentWeapon;

    public void GetInput()
    {
        currentWeapon = PlayerAccount.currentWeapon;
        //Debug.Log("Got PlayerAccount: " + currentWeapon);
        if(currentWeapon == null)
        {
            currentWeapon = "Bakunawa (Worn)";
            //Debug.Log("Bakunawa (Worn)");
        }
        foreach (GameObject go in Weapons)
        {
            //Debug.Log("1");
            if (go.name == currentWeapon)
            {
                equippedWeapon = go.GetComponent<WeaponController>();
                //Debug.Log("Got script: " + equippedWeapon);
                break;
            }
            //Debug.Log("2");
        }

        Attack();
    }

    public void Attack()
    {
        //string debugstring = equippedWeapon.debugName;
        equippedWeapon.CheckCombatInput();
        //Debug.Log(debugstring);
    }

    /*
    public void Find()
    {
        GameObject Weapons(GameObject[] g, string name)
        {
            for (int i = 0; i < g.Length; i++)
            {
                if (g[i].name == name)
                    return g[i];
            }

            Debug.Log("No item has the name '" + name + "'.");
            return null;
        }
    }
    */
}
