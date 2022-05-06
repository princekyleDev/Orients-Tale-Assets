using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerGUIBar : MonoBehaviour
{
    PlayerController Player;
    private Image HealthBar;
    public Image StaminaBar;
    public TMP_Text HealthText;

    // Health
    [Header("Health")]
    public float totalHealth;
    public float maxHealth;
    public float currentHealth;
    public bool hasBonusHealth;

    // Stamina
    [Header("Stamina")]
    public float totalStamina;
    public float maxStamina;
    public float currentStamina;
    public bool hasBonusStamina;

    [SerializeField]
    [Header("Regen")]
    private float healthRegenTime = .1f;
    [SerializeField]
    private float staminaRegenTime = 1f;
    public bool isDamaged = false;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        updateHealthBar();
        regenHealth();
        updateStaminaBar();
    }

    public void updateStaminaBar()
    {
        currentStamina = PlayerAccount.currentStamina;
        maxStamina = PlayerAccount.maxStamina;
        totalStamina = PlayerAccount.totalStamina;

        // Stamina Bool
        if (PlayerAccount.modifiedStamina != 0)
        {
            hasBonusStamina = true;
        }
        else
        {
            hasBonusStamina = false;
        }

        // Has modified Stamina
        if (hasBonusStamina == true)
        {
            if (currentStamina == maxStamina)
            {
                PlayerAccount.currentStamina = PlayerAccount.totalStamina;
            }
            if (currentStamina != totalStamina)
            {
                //Regen Stamina
                if (staminaRegenTime >= 0)
                {
                    staminaRegenTime -= Time.deltaTime;
                }
                else
                {
                    staminaRegenTime = .4f;
                    if((PlayerAccount.currentStamina + 4) > totalStamina)
                    {
                        // If exceeds max stamina
                        PlayerAccount.currentStamina = PlayerAccount.totalStamina;
                    }
                    else
                    {
                        // Add Stamina
                        PlayerAccount.currentStamina += 4;
                        //Debug.Log(" " + PlayerAccount.totalStamina);
                        //Debug.Log(" " + PlayerAccount.currentStamina);
                    }
                }
             }
            StaminaBar.fillAmount = currentStamina / totalStamina;
        }
        // Has no modified Stamina
        if (hasBonusStamina == false)
        {
            if (currentHealth >= maxHealth)
            {
                PlayerAccount.currentHealth = PlayerAccount.maxHealth;
            }
            if (currentStamina != maxStamina)
            {
                //Regen Stamina
                if (staminaRegenTime >= 0)
                {
                    staminaRegenTime -= Time.deltaTime;
                }
                else
                {
                    staminaRegenTime = .5f;
                    if ((PlayerAccount.currentStamina + 4) > maxStamina)
                    {
                        // If exceeds max stamina
                        PlayerAccount.currentStamina = PlayerAccount.maxStamina;
                    }
                    else
                    {
                        // Add Stamina
                        staminaRegenTime = .5f;
                        PlayerAccount.currentStamina += 2;
                    }
                }
            }
            StaminaBar.fillAmount = currentStamina / maxStamina;
        }
    }

    public void updateHealthBar()
    {
        currentHealth = PlayerAccount.currentHealth;
        maxHealth = PlayerAccount.maxHealth;
        totalHealth = PlayerAccount.totalHealth;

        // Health Bool
        if (PlayerAccount.modifiedHealth != 0 || PlayerAccount.totalHealth > 100)
        {
            hasBonusHealth = true;
        }
        else
        {
            hasBonusHealth = false;
        }

        // Has modified Health
        if (hasBonusHealth == true)
        {
            if (isDamaged == false)
            {
                if (currentHealth == maxHealth)
                {
                    PlayerAccount.currentHealth = PlayerAccount.totalHealth;
                }
            }

            if (currentHealth > totalHealth)
            {
                PlayerAccount.currentHealth = PlayerAccount.totalHealth;
            }

            HealthBar.fillAmount = currentHealth / totalHealth;
            HealthText.text = ("" + currentHealth + "/" + totalHealth);
        }

        // Has no modified Health
        if (hasBonusHealth == false)
        {
            if (isDamaged == false)
            {
                if (currentHealth >= maxHealth)
                {
                    PlayerAccount.currentHealth = PlayerAccount.maxHealth;
                }
            }

            if (currentHealth > maxHealth)
            {
                PlayerAccount.currentHealth = PlayerAccount.maxHealth;
            }

            HealthBar.fillAmount = currentHealth / maxHealth;
            HealthText.text = ("" + currentHealth + "/" + maxHealth);
        }
    }

    //public void NewGameHealthBar()
    //{
    //    currentHealth = PlayerAccount.currentHealth;
    //    maxHealth = PlayerAccount.maxHealth;

    //    HealthBar.fillAmount = currentHealth / maxHealth;
    //    HealthText.text = ("" + currentHealth + "/" + maxHealth);
    //}

    public void DisableHealthRegen()
    {
        PlayerAccount.inSafeZone = false;
    }

    public void EnableHealthRegen() 
    {
        PlayerAccount.inSafeZone = true;
    }

    public void regenHealth()
    {
        if (PlayerAccount.inSafeZone == true)
        {
            if (hasBonusHealth == true)
            {
                if (currentHealth < totalHealth)
                {
                    //Regen Stamina
                    if (healthRegenTime >= 0)
                    {
                        healthRegenTime -= Time.deltaTime;
                    }
                    else
                    {
                        healthRegenTime = .2f;
                        if ((PlayerAccount.currentHealth + 4) > totalHealth)
                        {
                            // If exceeds max stamina
                            PlayerAccount.currentHealth = PlayerAccount.totalHealth;
                        }
                        else
                        {
                            PlayerAccount.currentHealth += 4;
                        }
                    }
                }
                HealthBar.fillAmount = currentHealth / totalHealth;
            }

            if (hasBonusHealth == false)
            {
                if (currentHealth < maxHealth)
                {
                    //Regen Stamina
                    if (healthRegenTime >= 0)
                    {
                        healthRegenTime -= Time.deltaTime;
                    }
                    else
                    {
                        healthRegenTime = .2f;
                        if ((PlayerAccount.currentHealth + 4) > maxHealth)
                        {
                            PlayerAccount.currentHealth = PlayerAccount.maxHealth;
                        }
                        else
                        {
                            PlayerAccount.currentHealth += 4;
                        }
                    }
                }
                HealthBar.fillAmount = currentHealth / maxHealth;
            }
        }
    }

    public void PlayerIsDamaged()
    {
        isDamaged = true;
        //Debug.Log("Damaged!: " + isDamaged);
    }

    public void RevivePlayer()
    {
        if (hasBonusHealth == true)
        {
            PlayerAccount.currentHealth = PlayerAccount.totalHealth;
            HealthBar.fillAmount = currentHealth / totalHealth;
        }
        else
        {
            PlayerAccount.currentHealth = 100;
            HealthBar.fillAmount = currentHealth / maxHealth;
        }

        PlayerAccount.isDead = false;
    }
}
