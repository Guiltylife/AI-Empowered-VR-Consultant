using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    UIController uiController;
    [SerializeField]
    InputManager inputManager;
    [SerializeField]
    SceneController sceneController;
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    GameObject hammer;
    [SerializeField]
    GameObject muyu;
    [SerializeField]
    RespondGeneration respondGeneration;
    [SerializeField]
    SpeechSynthesis speechSynthesis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        uiController.Notify("pauseMenu", false);
    }

    public void Restart()
    {
        uiController.Notify("reset");
        uiController.Notify("tip1", true);
        uiController.Notify("tip4", true);

        ResetFunctions();
    }

    public void Quit()
    {
        uiController.Notify("reset");
        uiController.Notify("title", true);

        ResetFunctions();

        inputManager.isStart = false;
        hammer.GetComponent<XRGrabInteractable>().enabled = false;
    }

    private void ResetFunctions()
    {
        hammer.GetComponent<Hammer>().Reset();
        muyu.GetComponent<Muyu>().Reset();
        characterController.Notify("reset");
        sceneController.Notify("reset");
        respondGeneration.StartConversation();
        speechSynthesis.Reset();
    }
}
