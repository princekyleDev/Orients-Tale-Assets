using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public MonoliskController enemyController;
    public MonoliskMasterController enemyMasterController;
    [SerializeField]
    private Image HealthBar;
    [SerializeField]
    private TMP_Text HealthText;

    [Header("Health")]
    public float maxHealth;
    public float currentHealth;

    [Header("Type")]
    public bool isMaster = false;


    // Update is called once per frame
    void Update()
    {
        if(isMaster == false)
        {
            currentHealth = enemyController.currentHealth;
            maxHealth = enemyController.maxHealth;

            if(currentHealth <= 0)
            {
                HealthText.text = ("0" + "/" + maxHealth);
            }
            else
            {
                HealthBar.fillAmount = currentHealth / maxHealth;
                HealthText.text = ("" + currentHealth + "/" + maxHealth);
            }
        }
        else
        {
            currentHealth = enemyMasterController.currentHealth;
            maxHealth = enemyMasterController.maxHealth;

            if (currentHealth <= 0)
            {
                HealthText.text = ("0" + "/" + maxHealth);
            }
            else
            {
                HealthBar.fillAmount = currentHealth / maxHealth;
                HealthText.text = ("" + currentHealth + "/" + maxHealth);
            }
        }

    }
}
