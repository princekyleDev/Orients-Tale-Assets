using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    public int currentStamina;

    [Header("Weapon Info")]
    [SerializeField]
    //public Sprite weaponImage;
    public int weaponDamage;
    public int baseDamage;
    public int totalDamage;

    private Animator anim;
    [Header("Components")]
    [SerializeField]
    //public Button attackButton;
    public GameObject hoodToggle;

    [Header("States")]
    [SerializeField]
    public bool combatEnabled = false;
    public bool canAttack = true;
    private bool gotInput;
    private bool isAttacking;

    [Header("Attack Hitbox")]
    [SerializeField]
    private Transform attackHitBox;
    public float attackHitBoxRadius;

    [Header("LayerMasks")]
    [SerializeField]
    private LayerMask whatIsDamageable;

    [Header("Audio Sources")]
    public AudioSource gamePlayFx;

    [Header("Audio Fx")]
    public AudioClip swordSwingFx;

    public string debugName = " ";

    private void Start()
    {
        baseDamage = PlayerAccount.baseDamage;
        anim = GetComponent<Animator>();
        anim.SetBool("CanAttack", combatEnabled);

        Debug.Log("Test");
    }

    private void Update()
    {

        totalDamage = PlayerAccount.totalDamage;
        currentStamina = PlayerAccount.currentStamina;

        CheckEquippedItem();
        CheckStamina();
        if (isAttacking == true)
        {
            canAttack = false;
            hoodToggle.SetActive(false);
            CheckAttackHitbox();
        }
        else
        {
            canAttack = true;
            hoodToggle.SetActive(true);
        }

    }

    public void CheckEquippedItem()
    {
        if (totalDamage == 0)
        {
            weaponDamage = baseDamage;
        }
        else
        {
            weaponDamage = totalDamage;
        }

    }


    public void CheckStamina()
    {
        if ((currentStamina - 10) <= 0)
        {
            canAttack = false;
        }
        else
        {
            canAttack = true;
            CheckAttacks();
        }
    }

    public void CheckCombatInput()
    {
        if (combatEnabled)
        {
            if (canAttack == true)
            {
                //Debug.Log("Attack!");
                gotInput = true;
            }
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            //Perform attack1
            if (!isAttacking)
            {
                //Debug.Log("Attack" + PlayerAccount.totalStamina);
                //Debug.Log("Attack" + PlayerAccount.currentStamina);
                PlayerAccount.currentStamina -= 20;
                gamePlayFx.PlayOneShot(swordSwingFx);
                gotInput = false;
                isAttacking = true;
                anim.SetBool("IsAttacking", isAttacking);
            }
        }
    }

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("Damage", weaponDamage);
            Debug.Log("Hit!!!!!!!!!!!!!!!!");
        }
    }
    */

    public void CheckAttackHitbox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackHitBox.position, attackHitBoxRadius, whatIsDamageable);
        //Debug.Log("Attack!");

        foreach (Collider2D collider in detectedObjects)
        {
            collider.gameObject.SendMessage("Damage", weaponDamage);
        }
    }

    public void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("IsAttacking", isAttacking);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackHitBox.position, attackHitBoxRadius);
    }

}
