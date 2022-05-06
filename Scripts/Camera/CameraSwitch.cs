using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera GamePlay;
    [SerializeField] CinemachineVirtualCamera CharacterMenu;

    private void OnEnable()
    {
        CameraSwitcher.Register(GamePlay);
        CameraSwitcher.Register(CharacterMenu);
        CameraSwitcher.SwitchCamera(GamePlay);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(GamePlay);
        CameraSwitcher.Unregister(CharacterMenu);
    }

    public void ChangeCamera()
    {
        if(CameraSwitcher.IsActiveCamera(CharacterMenu))
        {
            CameraSwitcher.SwitchCamera(GamePlay);
        }
        else if (CameraSwitcher.IsActiveCamera(GamePlay))
        {
            CameraSwitcher.SwitchCamera(CharacterMenu);
        }
    }
}
