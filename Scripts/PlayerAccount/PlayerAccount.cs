using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccount : MonoBehaviour
{
    public static int level;

    // States
    public static bool isDead = false;

    // Zones
    public static bool inSafeZone = false;

    // Health
    public static int totalHealth;
    public static int modifiedHealth;
    public static int maxHealth = 100;
    public static int currentHealth = 100;
    public static int healthRegen;

    //Stamina
    public static int totalStamina;
    public static int modifiedStamina;
    public static int maxStamina = 100;
    public static int currentStamina = 100;
    public static int staminaRegen;

    // Stats
    public static int totalArmor;
    public static int baseArmor;
    public static int modifiedArmor;

    public static int totalDamage;
    public static int baseDamage = 5;
    public static int modifiedDamage;

    public static int totalEvasion;
    public static int baseEvasion;
    public static int modifiedEvasion;

    public static int Health;
    public static int Stamina;

    /*
    public static int Strength;
    public static int Agility;
    public static int Intellect;
    **/

    // Movement Speed
    public static float msHooded;
    public static float msUnhooded;


    ///// Items /////////////////

    // modifiedStats
    public static string equipNameModified; 
    public static string equipDescModified;
    public static int ratingModified;
    public static int healthModified;
    public static int staminaModified;
    public static int armorModified;
    public static int damageModified;
    public static int evasionModified;

    //// Charms
    public static string currentCharms;
    public static string descriptionCharms;
    //public static string ratingCharms;
    //public static int healthCharms;
    //public static int staminaCharms;
    //public static int armorCharms;
    //public static int damageCharms;
    //public static int evasionCharms;

    //// Armor
    public static string currentArmor;
    //public static string ratingArmor;
    public static string descriptionArmor;
    //public static int healthArmor;
    //public static int staminaArmor;
    //public static int armorArmor;
    //public static int damageArmor;
    //public static int evasionArmor;

    //// Weapons
    public static string currentWeapon;
    public static string descriptionWeapon;
    //public static string ratingWeapon;
    //public static int healthWeapon;
    //public static int staminaWeapon;
    //public static int armorWeapon;
    //public static int damageWeapon;
    //public static int evasionWeapon;

    //// Gold
    //public static int Gold;

    // Almanacs
    public bool Diwata;
    public bool Dungan;
    public bool Kaluluwa;
    public bool Duwende;
    public bool Kapre;
}
