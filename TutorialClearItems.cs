using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialClearItems : MonoBehaviour
{
    public PlayerInventory playerInventoryProfile;

    public GameObject ClearItems;

    public bool hasFired = false;

    public void StartClearItems()
    {
        if (hasFired == false)
        {
            playerInventoryProfile.ClearItems();
            Debug.Log("[StartClearItems] Spawn Cleared Items!");
            hasFired = true;
            ClearItems.SetActive(false);
        }

    }
}
