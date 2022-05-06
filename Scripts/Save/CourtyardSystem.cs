using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtyardSystem : MonoBehaviour
{
    public GameObject Bakunawa1SZ;

    private void Start()
    {
        if (PlayerQuests.hasBakunawa1SZ == false)
        {
            Bakunawa1SZ.SetActive(true);
        }
    }

    public void hasBakunawa1SZPickedUp()
    {
        PlayerQuests.hasBakunawa1SZ = true;
        Debug.Log("Collided: " + PlayerQuests.hasBakunawa1SZ);
    }


}
