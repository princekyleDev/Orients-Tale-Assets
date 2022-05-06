using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    [Header("Set Up/Down Motion")]
    [Tooltip("Check this to Float")]
    public bool checkToFloat;
    public float height = 0.5f;
    public float upDownSpeed = 1f;

    [SerializeField] private FlashEffect flashEffectScript;

    // Position Storage Variables
    Vector2 startingPosition = new Vector2();
    Vector2 tempPosition = new Vector2();

    void Start()
    {
        // Store the starting position & rotation of the object
        startingPosition = transform.position;
    }

    void Update()
    {

        // float object up and down
        if (checkToFloat)
        {
            tempPosition = startingPosition;
            tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * upDownSpeed) * height;
            transform.position = tempPosition;

            if (tempPosition == startingPosition)
            {
                FlashOn();
            }
        }
    }

    public void FlashOn()
    {
        flashEffectScript.Flash();
    }
}
