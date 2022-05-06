using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[Header("Components")]
	[SerializeField]
	public Joystick joystick;
	public Rigidbody2D rigidBody2D;
	public Toggle hoodT;
	public Animator animator;
	PlayerGUIBar PlayerHUD;

	[Header("Player Stats")]
	public int maxHealth;
	public int totalDamage;
	public int currentHealth;
	public int currentEvasion;
	public int currentArmor;
	public int healthRegen = 1;
	public float timeValue = 2.5f;

	[Header("Game Objects")]
	[SerializeField]
	private GameObject weapon, interactable, PlayerHud;

	[Header("Game Over UI")]
	[SerializeField]
	private GameObject GameOver;

	[Header("Movement Statistics")]
	public float msHooded, msUnhooded, movementSpeed;

	[Header("States")]
	public bool canbeDamaged = true;
	public bool isDead = false;
	public bool facingRight = true;
	public bool canFlip = true;
	public bool isHooded = true;
	public bool canHood = true;

	[Header("Get States")]
	private int hoodMode = 1;
	private int facingDirection = 0;

	[Header("Debug")]
	[SerializeField]
	public bool isDebugOn;

	[Header("Audio Sources")]
	public AudioSource gamePlayFx;

	[Header("Audio Fx")]
	public AudioClip pickUpFx;
	public AudioClip playerHurtFx;
	public AudioClip playerRegenFx;

	private float horizontalMove = 0f;
	private float verticalMove = 0f;

	[Header("Un/Hooded Particle")]
	public GameObject particleEffect;

	[Header("Flash Hurt Effect")]
	[SerializeField] 
	private FlashEffect simpleFlashEffect;

	void Start()
	{
		PlayerHUD = FindObjectOfType<PlayerGUIBar>();
		PlayerRespawn();
		//currentHealth = PlayerAccount.totalHealth;
		//maxHealth = PlayerAccount.maxHealth;
		//HealthRegen = GameObject.Find("UI/UI Gameplay/Player Health/Health Regen");	
	}

	void Update()
    {
		// Check Debug Mode
		CheckDebugMode();

		if (isDead != true)
        {
			// Movement
			//PlayerHealthRegen();
			CheckMovementInput();
		}
		else
        {
			horizontalMove = 0f;
			verticalMove = 0f;
			animator.SetFloat("Speed", 0);
			//HealthRegen.SetActive(false);

		}
	}

	private void CheckDebugMode() 
	{
		//Debug Toggle
		if (isDebugOn == true)
		{
			if (this.transform.hasChanged)
			{
				//Debug.Log("Joystick Horizontal = " + joystick.Horizontal);
				//Debug.Log("Joystick Vertical = " + joystick.Vertical);
				//Debug.Log("Joystick Direction = " + joystick.Direction);
				//Debug.Log("Player Horizontal Speed = " + horizontalMove);
				//Debug.Log("Player Vertical Speed = " + verticalMove);
			}

			transform.hasChanged = false;
		}
	}

	private void CheckMovementInput() 
	{
		if (isHooded == true) 
		{
			// Speed value
			movementSpeed = msHooded;
		}
        else
        {
			// Speed value
			movementSpeed = msUnhooded;
		}

		horizontalMove = joystick.Horizontal * movementSpeed;
		verticalMove = joystick.Vertical * movementSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove + verticalMove));

		// Check Player states facing
		if (canFlip == true)
		{
			if (horizontalMove > 0 && !facingRight)
			{
				// Flip player right
				Flip();
			}
			else if (horizontalMove < 0 && facingRight)
			{
				// Flip player left
				Flip();
			}
		}
	}

	public void DisableFlip()
	{
		canFlip = false;
	}

	public void EnableFlip()
	{
		canFlip = true;
	}

	private void Flip()
	{
		// Switch the way the player labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public int GetFacingDirection()
	{
		return facingDirection;
	}

	public void HoodToggle()
	{
		if (canHood == true) 
		{ 
			if (isHooded != true)
			{
				// Particle Effect ////
				//Destroy(Instantiate(particleEffect.gameObject, transform.position, Quaternion.identity), 1f);
				Instantiate(particleEffect, transform.position, Quaternion.identity);
				// Flash /////
				simpleFlashEffect.Flash();

				interactable.SetActive(true);
				weapon.SetActive(false);

				isHooded = true;
				animator.SetBool("isHooded", true);
				hoodMode = 1;
			}
			else
			{
				// Particle Effect ////
				//Destroy(Instantiate(particleEffect.gameObject, transform.position, Quaternion.identity), 1f);
				Instantiate(particleEffect, transform.position, Quaternion.identity);
				// Flash /////
				simpleFlashEffect.Flash();

				interactable.SetActive(false);
				weapon.SetActive(true);

				isHooded = false;
				animator.SetBool("isHooded", false);
				hoodMode = 0;
			}
		}
	}

	public int GetCurrentHoodMode()
	{
		return hoodMode;
	}

	private void Damage(int amount)
	{
		if (canbeDamaged == true)
        {
			currentHealth = PlayerAccount.currentHealth;
			currentEvasion = PlayerAccount.totalEvasion;
			currentArmor = PlayerAccount.totalArmor;

			if ((currentHealth - amount) <= 0.0f)
			{
				animator.SetBool("isDead", true);
				PlayerHud.SetActive(false);
			}
			else
			{
				int enemyAttackRoll = Random.Range(1, 100);
				// Evasion Check
				if (enemyAttackRoll >= currentEvasion)
				{
					// Armor Check
					int totalDamage = amount - currentArmor;
					if (totalDamage <= 0)
					{
						totalDamage = 1;
					}
					currentHealth -= totalDamage;
					//Debug.Log("Raw Damage: " + amount);
					//Debug.Log("Received Damage: " + totalDamage);
					//Debug.Log("Armor: " + currentArmor);
					PlayerAccount.currentHealth = currentHealth;
					gamePlayFx.PlayOneShot(playerHurtFx);
					FlashPlayer();
					PlayerHUD.PlayerIsDamaged();
				}
				else
				{
					//Debug.Log("Miss Attack");
				}
			}
		}

		//if (currentHealth <= 0.0f)
		//{
		//	animator.SetBool("isDead", true);
		//	PlayerHud.SetActive(false);
		//}

		//Instantiate(hitParticle, aliveAnim.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
		//animator.SetTrigger("damage");
		//PlayerHealth();
	}

	public void CanBeDamagedEnable()
	{
		// From Death Animation
		canbeDamaged = true;
	}
	public void CanBeDamagedDisable()
	{
		// From Death Animation
		canbeDamaged = false;
	}
	public void PlayerRespawn()
    {
		PlayerAccount.isDead = false;
	}
	public void PlayerDead()
    {
		// From Death Animation
		PlayerAccount.isDead = true;
		Debug.Log("Player Dead");
		GameOver.SetActive(true);
	}
	public void FlashPlayer()
	{
		simpleFlashEffect.Flash();
	}
	public void FlashPlayer2()
    {
		simpleFlashEffect.Flash2();
	}
	public void PickUpFxSound()
    {
		gamePlayFx.PlayOneShot(pickUpFx);
	}

	void FixedUpdate()
	{
		// Move Player
		transform.position += new Vector3 (horizontalMove * movementSpeed * Time.fixedDeltaTime, verticalMove * movementSpeed * Time.fixedDeltaTime, 0);
	}
}
