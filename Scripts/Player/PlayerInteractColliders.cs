using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractColliders : MonoBehaviour
{
	PlayerController Player;

	[SerializeField]
	private GameObject questButton, talkButton, interactButton;

	[Header("Player States")]
	public int isHooded = 1;

	[Header("Interaction")]
	public float interactRadius;
	[SerializeField]
	private Transform interactHitBox;

	[Header("Pickable")]
	public float pickableRadius;
	[SerializeField]
	private Transform pickableHitBox;

	[Header("Quests")]
	[SerializeField]
	public QuestEventGathering quest;

	[Header("LayerMasks")]
	[SerializeField]
	private LayerMask whatIsIntereactable, whatIsPickable;

	private void Start()
	{
		Player = FindObjectOfType<PlayerController>();
	}

	private void Update()
	{
		isHooded = Player.GetCurrentHoodMode();
	}

	public void DialogueCollision()
	{
		if (isHooded == 0)
		{
			talkButton.SetActive(false);
		}
		else if (isHooded == 1)
		{
			talkButton.SetActive(true);
		}
	}

	public void DialogueTrigger()
	{
		Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(interactHitBox.position, interactRadius, whatIsIntereactable);

		foreach (Collider2D collider in detectedObjects)
		{
			collider.gameObject.SendMessage("StartDialogue");
		}
	}

	public void QuestCollision()
	{
		if (isHooded == 0)
		{
			questButton.SetActive(false);
		}
		else if (isHooded == 1)
		{
			questButton.SetActive(true);
		}
	}

	public void QuestTrigger()
	{
		Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(interactHitBox.position, interactRadius, whatIsIntereactable);

		foreach (Collider2D collider in detectedObjects)
		{
			collider.gameObject.SendMessage("StartDialogue");
		}

		quest.startQuestEvent = true;

	}

	public void IntereactableCollision()
	{
		if (isHooded == 0)
		{
			interactButton.SetActive(false);
		}
		else if (isHooded == 1)
		{
			interactButton.SetActive(true);
		}
	}

	public void IntereactableTrigger()
	{
		Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(interactHitBox.position, interactRadius, whatIsIntereactable);

		foreach (Collider2D collider in detectedObjects)
		{
			collider.gameObject.SendMessage("PickupItem");
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(interactHitBox.position, interactRadius);
		Gizmos.DrawWireSphere(pickableHitBox.position, pickableRadius);
	}
}
