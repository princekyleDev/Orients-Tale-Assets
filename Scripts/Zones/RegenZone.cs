using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenZone : MonoBehaviour
{
    [Header("Health")]
    public float totalHealth;
    public float maxHealth;
    public float currentHealth;
    public bool hasBonusHealth;

    [SerializeField]
    [Header("Regen")]
    public float healthRegenTime = .5f;

    /*
    public void regenHealth()
    {
        currentHealth = PlayerAccount.currentHealth;
        maxHealth = PlayerAccount.maxHealth;
        totalHealth = PlayerAccount.totalHealth;

        // Health Bool
        if (PlayerAccount.modifiedHealth != 0)
        {
            hasBonusHealth = true;
        }
        else
        {
            hasBonusHealth = false;
        }

        if (PlayerAccount.inSafeZone == true && hasBonusHealth == true)
        {
            if (currentHealth != totalHealth)
            {
                //Regen Stamina
                if (healthRegenTime >= 0)
                {
                    healthRegenTime -= Time.deltaTime;
                }
                else
                {
                    healthRegenTime = .5f;
                    if ((PlayerAccount.currentHealth + 4) > totalHealth)
                    {
                        // If exceeds max stamina
                        PlayerAccount.currentHealth = PlayerAccount.totalHealth;
                    }
                    else
                    {
                        // Add Stamina
                        PlayerAccount.currentHealth += 10;
                        //Debug.Log(" " + PlayerAccount.totalStamina);
                        //Debug.Log(" " + PlayerAccount.currentStamina);
                    }
                }
            }
            HealthBar.fillAmount = currentHealth / totalHealth;
        }

        else
        {
            if (PlayerAccount.inSafeZone == true && currentHealth != maxHealth)
            {
                //Regen Stamina
                if (healthRegenTime >= 0)
                {
                    healthRegenTime -= Time.deltaTime;
                }
                else
                {
                    healthRegenTime = .5f;
                    if ((PlayerAccount.currentHealth + 4) > maxHealth)
                    {
                        // If exceeds max stamina
                        PlayerAccount.currentHealth = PlayerAccount.maxHealth;
                    }
                    else
                    {
                        // Add Stamina
                        PlayerAccount.currentHealth += 10;
                        //Debug.Log(" " + PlayerAccount.totalStamina);
                        //Debug.Log(" " + PlayerAccount.currentStamina);
                    }
                }
            }
            HealthBar.fillAmount = currentHealth / totalHealth;
        }
    }
    */
}
