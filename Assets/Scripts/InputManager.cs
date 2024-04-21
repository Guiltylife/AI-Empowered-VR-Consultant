using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    InputActionReference pressA;
    [SerializeField]
    InputActionReference releaseA;
    [SerializeField]
    InputActionReference pressX;
    [SerializeField]
    InputActionReference pressY;

    [SerializeField]
    UIController uiController;
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    XRGrabInteractable hammer;

    public bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressA.action.WasPerformedThisFrame())
        {
            characterController.Notify("start record");
            uiController.Notify("error1", false);
        }

        if (releaseA.action.WasPerformedThisFrame())
        {
            characterController.Notify("stop record");
            uiController.Notify("tip3", false);
        }

        if (pressX.action.WasPerformedThisFrame())
        {
            if(!isStart)
            {
                uiController.Notify("title", false);
                uiController.Notify("tip1", true);
                uiController.Notify("tip4", true);
                hammer.enabled = true;
                isStart = true;
            }
        }

        if (pressY.action.WasPerformedThisFrame())
        {
            if (isStart) uiController.Notify("pauseMenu", true);
        }
    }
}
