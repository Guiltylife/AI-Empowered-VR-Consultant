using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpeechRecognition speechRecognition;
    [SerializeField]
    InputActionReference buttonAPress;
    [SerializeField]
    InputActionReference buttonARelease;

    private double timer = 0;
    private bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (timer > 0) timer -= Time.deltaTime;

        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                speechRecognition.StartRecording();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                speechRecognition.StopRecording();
            }

            if (buttonAPress.action.WasPerformedThisFrame())
            {
                speechRecognition.StartRecording();
            }

            if (buttonARelease.action.WasPerformedThisFrame())
            {
                speechRecognition.StopRecording();
            }
        }
    }

    public void Notify(string type, string text)
    {
        if (type == "movement")
        {
            movement(text);
        }
    }

    private void movement(string text)
    {
        if (text == "up")
        {
            animator.SetTrigger("Up");
            timer = 30;
            isActive = true;
        } else if (text == "down")
        {
            animator.SetTrigger("Down");
            timer = 0;
            isActive = false;
        } else
        {
            Debug.Log("Unknow movement!!!");
        }
    }
}
