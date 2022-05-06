using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJoystickRotation : MonoBehaviour
{
	public Joystick joystick;
	public GameObject Object;
	Vector2 GameobjectRotation;
	private float GameobjectRotation2;
	private float GameobjectRotation3;

	// public GameObject pivot;
	// public GameObject player;
	// public float lookSpeed = 50;

	// public Transform autoAimHitBox;
	// public float autioAimRadius;

	// [SerializeField]
	// private LayerMask whatIsEnemy;

	public bool FacingRight = true;

	void Update()
	{
		//Gets the input from the jostick
		GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);
		GameobjectRotation3 = GameobjectRotation.x;

		if (FacingRight)
		{
			//Rotates the object if the player is facing right
			GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * 90;
			Object.transform.rotation = Quaternion.Euler(0f, 0f, GameobjectRotation2);
		}
		else
		{
			//Rotates the object if the player is facing left
			GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * -90;
			Object.transform.rotation = Quaternion.Euler(0f, 180f, -GameobjectRotation2);
		}
		if (GameobjectRotation3 < 0 && FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}
		else if (GameobjectRotation3 > 0 && !FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}

		//checkEnemies();
	}

	/*
	public void checkEnemies()
    {
		var detectedObjects = Physics2D.OverlapCircle(autoAimHitBox.position, autioAimRadius, whatIsEnemy);
		if (detectedObjects != null)
		{ 
			Vector3 direction = player.transform.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * lookSpeed);
			Debug.Log("Enemy is near!");
        }
		else
        {
			Debug.Log("No enemies near!");
		}
	}
	*/

	private void Flip()
	{
		// Flips the player.
		FacingRight = !FacingRight;

		transform.Rotate(0, 180, 0);

		// Multiply the player's x local scale by -1.
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/*
	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(autoAimHitBox.position, autioAimRadius);
	}
	*/
}
