using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FPS : MonoBehaviour
{
    public Text fpsDisplay;
    int framesPassed = 0;
    public Text minFPSDisplay, maxFPSDisplay;
    float minFPS = Mathf.Infinity;
    float maxFPS = 0f;
    float fpsTotal = 0f;

    // Update is called once per frame
    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;
        int fps2 = (int)Math.Round(fps);
        fpsDisplay.text = "FPS: " + fps2;

        fpsTotal += fps;
        framesPassed++;

        if (fps > maxFPS && framesPassed > 10)
        {
            maxFPS = fps;
            maxFPSDisplay.text = "Max: " + maxFPS;
        }
        if (fps < minFPS && framesPassed > 10)
        {
            minFPS = fps;
            minFPSDisplay.text = "Min: " + minFPS;
        }
    }

}
