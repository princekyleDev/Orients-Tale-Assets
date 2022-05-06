using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class AttributesInterface : MonoBehaviour
{
    public int state = 1;

    // Attributes
    public TextMeshProUGUI maxHealth;
    public TextMeshProUGUI maxStamina;
    public TextMeshProUGUI Armor;
    public TextMeshProUGUI Damage;
    public TextMeshProUGUI Evasion;
    public TextMeshProUGUI Gold;

    // Item Desciption
    public TextMeshProUGUI equipName;
    public TextMeshProUGUI equipDesc;
    //public TextMeshProUGUI equipRating;
    public TextMeshProUGUI equipHealth;
    public TextMeshProUGUI equipStamina;
    public TextMeshProUGUI equipArmor;
    public TextMeshProUGUI equipDamage;
    public TextMeshProUGUI equipEvasion;

    public void Update()
    {
        maxHealth.text = "" + PlayerAccount.totalHealth;
        maxStamina.text = "" + PlayerAccount.totalStamina;
        Armor.text = "" + PlayerAccount.totalArmor;
        Damage.text = "" + PlayerAccount.totalDamage;
        Evasion.text = "" + PlayerAccount.totalEvasion + "%";
        //Gold.text = "" + PlayerAccount.totalGold;

        /*
        equipName.text = "" + PlayerAccount.equipNameModified;
        equipDesc.text = "" + PlayerAccount.equipDescModified;
        //RatingCalc();
        equipHealth.text = "" + PlayerAccount.healthModified;
        equipStamina.text = "" + PlayerAccount.staminaModified;
        equipArmor.text = "" + PlayerAccount.armorModified;
        equipDamage.text = "" + PlayerAccount.damageModified;
        equipEvasion.text = "" + PlayerAccount.evasionModified;
        */

        equipName.text = "" + PlayerAccount.equipNameModified;
        equipDesc.text = "" + PlayerAccount.equipDescModified;
        //RatingCalc();
        equipHealth.text = "" + PlayerAccount.modifiedHealth;
        equipStamina.text = "" + PlayerAccount.modifiedStamina;
        equipArmor.text = "" + PlayerAccount.modifiedArmor;
        equipDamage.text = "" + PlayerAccount.modifiedDamage;
        equipEvasion.text = "" + PlayerAccount.modifiedEvasion;


        //    switch (state)
        //    {
        //        case 1:
        //            equipName.text = "" + PlayerAccount.currentCharms;
        //            equipDesc.text = "" + PlayerAccount.descriptionCharms;
        //            equipRating.text = "" + PlayerAccount.ratingCharms;

        //            //equipHealth.text = "" + PlayerAccount.healthCharms;
        //            //equipStamina.text = "" + PlayerAccount.staminaCharms;
        //            //equipArmor.text = "" + PlayerAccount.armorCharms;
        //            //equipDamage.text = "" + PlayerAccount.damageCharms;
        //            //equipEvasion.text = "" + PlayerAccount.evasionCharms;
        //            break;

        //        case 2:
        //            equipName.text = "" + PlayerAccount.currentArmor;
        //            equipDesc.text = "" + PlayerAccount.descriptionArmor;
        //            equipRating.text = "" + PlayerAccount.ratingArmor;

        //            //equipHealth.text = "" + PlayerAccount.healthArmor;
        //            //equipStamina.text = "" + PlayerAccount.staminaArmor;
        //            //equipArmor.text = "" + PlayerAccount.armorArmor;
        //            //equipDamage.text = "" + PlayerAccount.damageArmor;
        //            //equipEvasion.text = "" + PlayerAccount.evasionArmor;
        //            break;

        //        case 3:
        //            equipName.text = "" + PlayerAccount.currentWeapon;
        //            equipDesc.text = "" + PlayerAccount.descriptionWeapon;
        //            equipRating.text = "" + PlayerAccount.ratingWeapon;

        //            //equipHealth.text = "" + PlayerAccount.healthWeapon;
        //            //equipStamina.text = "" + PlayerAccount.staminaWeapon;
        //            //equipArmor.text = "" + PlayerAccount.armorWeapon;
        //            //equipDamage.text = "" + PlayerAccount.damageWeapon;
        //            //equipEvasion.text = "" + PlayerAccount.evasionWeapon;
        //            break;

        //        default:
        //            equipName.text = "No Item";
        //            equipDesc.text = "No Item";
        //            equipRating.text = "NA";
        //            equipHealth.text = "0";
        //            equipStamina.text = "0";
        //            equipArmor.text = "0";
        //            equipDamage.text = "0";
        //            equipEvasion.text = "0";
        //            break;
        //    }

    }

    /*
    public void RatingCalc()
    {
        int rating = PlayerAccount.ratingModified;
        int health = PlayerAccount.healthModified;
        int stamina = PlayerAccount.staminaModified;
        int armor = PlayerAccount.armorModified;
        int damage = PlayerAccount.damageModified;
        int evasion =  PlayerAccount.evasionModified;
        int total = 0;
        List<int> intList = new List<int>() { health, stamina, armor, damage, evasion };
        total = intList.Aggregate((x, y) => x + y);
        switch (rating)
        {
            case 1:
                switch (total)
                {
                    case int n when (n <= 25):
                        equipRating.text = "1D";
                        break;

                    case int n when (n <= 30 && n >= 26):
                        equipRating.text = "1C";
                        break;

                    case int n when (n <= 35 && n >= 31):
                        equipRating.text = "1B";
                        break;
                    case int n when (n <= 39 && n >= 36):
                        equipRating.text = "1A";
                        break;
                    case int n when (n == 40):
                        equipRating.text = "1S";
                        break;
                }
                break;
            case 2:
                switch (total)
                {
                    case int n when (n <= 35):
                        equipRating.text = "2D";
                        break;

                    case int n when (n <= 40 && n >= 36):
                        equipRating.text = "2C";
                        break;

                    case int n when (n <= 45 && n >= 41):
                        equipRating.text = "2B";
                        break;
                    case int n when (n <= 49 && n >= 46):
                        equipRating.text = "2A";
                        break;
                    case int n when (n == 50):
                        equipRating.text = "2S";
                        break;
                }
                break;
            case 3:
                switch (total)
                {
                    case int n when (n <= 45):
                        equipRating.text = "3D";
                        break;

                    case int n when (n <= 50 && n >= 46):
                        equipRating.text = "3C";
                        break;

                    case int n when (n <= 55 && n >= 51):
                        equipRating.text = "3B";
                        break;
                    case int n when (n <= 59 && n >= 56):
                        equipRating.text = "3A";
                        break;
                    case int n when (n == 60):
                        equipRating.text = "3S";
                        break;
                }
                break;
            case 4:
                switch (total)
                {
                    case int n when (n <= 55):
                        equipRating.text = "4D";
                        break;

                    case int n when (n <= 60 && n >= 56):
                        equipRating.text = "4C";
                        break;

                    case int n when (n <= 65 && n >= 61):
                        equipRating.text = "4B";
                        break;
                    case int n when (n <= 69 && n >= 66):
                        equipRating.text = "4A";
                        break;
                    case int n when (n == 70):
                        equipRating.text = "4S";
                        break;
                }
                break;
        }
    }
    */

    //public void equipStateCharm()
    //{
    //    state = 1;
    //}

    //public void equipStateArmor()
    //{
    //    state = 2;
    //}

    //public void equipStateWeapon()
    //{
    //    state = 3;
    //}
}
