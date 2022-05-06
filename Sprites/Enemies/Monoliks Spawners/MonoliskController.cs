using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoliskController : MonoBehaviour
{
    public Animator animator;
    [Header("Quest")]
    MainQuest questHandler;

    MonoliskMasterController MonoliskMaster;

    [Header("GameObjects")]
    public GameObject TriggerEvent;
    public GameObject SpawnerRight;
    public GameObject SpawnerLeft;
    public GameObject PitGate;

    [Header("GameObjects")]
    public GameObject HealthHUD;

    [Header("Monolisk Stats")]
    public int maxHealth = 200;
    public int currentHealth;

    [Header("Monolisk Stats")]
    public bool isMini = false;

    [Header("Monolisk States")]
    public bool canBeAttacked = true;
    public bool isDead = false;

    [Header("Audio Sources")]
    public AudioSource gamePlayFx;

    [Header("Audio Fx")]
    public AudioClip enemyHitFx;

    // HitEffect
    [SerializeField] private FlashEffect simpleFlashEffect;

    void Start()
    {
        currentHealth = maxHealth;
        if (isMini == false)
        {
            questHandler = FindObjectOfType<MainQuest>();
        }
        else
        {
            MonoliskMaster = FindObjectOfType<MonoliskMasterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Damage(int amount)
    {
        if (canBeAttacked == true)
        {
            amount = PlayerAccount.totalDamage;
            if (amount == 0)
            {
                amount = 5;
            }

            currentHealth -= amount;
            // Hit Effects
            //Instantiate(hitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            gamePlayFx.PlayOneShot(enemyHitFx);
            simpleFlashEffect.Flash();

            if (currentHealth <= 0.0f)
            {
                //aliveGO.SetActive(false);
                isDead = true;
                animator.SetBool("isDead", isDead);
                canBeAttacked = false;
                if(isMini == false)
                {
                    CallDead();
                }
                else
                {
                    CallDeadMini();
                }
            }

            if (isMini == false)
            {
                if (currentHealth <= 50)
                {
                    SpawnerLeft.SetActive(false);
                }
            }

            animator.SetTrigger("Hurt");
            //Debug.Log("Hit!:" + amount + " Monolisk Health: " + currentHealth);
        }
        canBeAttacked = false;
    }

    public void EnableDamage()
    {
        canBeAttacked = true;
    }

    public void DisableDamage()
    {
        canBeAttacked = false;
    }

    public void CallDead()
    {
        SpawnerRight.SetActive(false);
        SpawnerLeft.SetActive(false);
        PitGate.SetActive(false);
        HealthHUD.SetActive(false);
        TriggerEvent.SetActive(false);
        questHandler.UpdateMainQuest();
    }

    public void CallDeadMini()
    {
        MonoliskMaster.MiniDestroyed();
    }
}
