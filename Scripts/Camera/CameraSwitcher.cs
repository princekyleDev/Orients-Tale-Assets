using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitcher
{
    public static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        //List foreach search and compare
        foreach (CinemachineVirtualCamera c in cameras)
        {
            if (c != camera && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }
    }

    public static void Register(CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
        //Debug.Log("Camera Registered: " + camera);
    }

    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
        //Debug.Log("Camera Unegistered: " + camera);
    }


}
