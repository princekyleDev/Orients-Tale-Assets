using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoliskMasterController : MonoBehaviour
{
    public Animator animator;

    [Header("Quest")]
    FinalMainQuest questHandler;
    PlayerController Player;
    SpeedrunTimer spdTimer;
    //PlayerInventory playerInv;
    LoadingScreen loadLevel;

    [Header("GameObjects")]
    public GameObject Spawners;
    public GameObject PlayerHUD;
    public GameObject HealthHUD;
    public GameObject EndScene;

    [Header("Monolisk Stats")]
    public int maxHealth = 500;
    public int currentHealth;

    [Header("Mini Monolisk Stats")]
    public int totalMinis = 4;

    [Header("Spawner to Deactivate")]
    public GameObject destroyableSpawner;

    [Header("Death Triggers")]
    public bool loadLevelAfterDeath;
    [SerializeField]
    private int levelToLoad;

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
        questHandler = FindObjectOfType<FinalMainQuest>();
        Player = FindObjectOfType<PlayerController>();
        spdTimer = FindObjectOfType<SpeedrunTimer>();
        //playerInv = FindObjectOfType<PlayerInventory>();
        loadLevel = FindObjectOfType<LoadingScreen>();
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
                CallDead();
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

    public void MiniDestroyed()
    {
        totalMinis = --totalMinis;
        currentHealth = currentHealth - 80;
        Debug.Log("totalMinis: " + totalMinis);

        if (totalMinis >= 2)
        {
            destroyableSpawner.SetActive(false);
        }
    }

    public void CallDead()
    {
        Spawners.SetActive(false);
        Player.CanBeDamagedDisable();
        HealthHUD.SetActive(false);

        spdTimer.FinishTimer();

        //playerInv.ClearItems();
        //EndScene.SetActive(true);
        if (loadLevelAfterDeath == true)
        {
            loadLevel.LoadLevel(levelToLoad);
        }
    }
}
