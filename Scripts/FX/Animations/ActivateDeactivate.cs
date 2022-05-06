using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Object;
    public void ActivateObject()
    {
        Object.SetActive(true);
    }

    public void DeactivateObject()
    {
        Object.SetActive(false);
    }
}
