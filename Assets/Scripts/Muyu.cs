using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muyu : MonoBehaviour
{
    [SerializeField]
    UIController uiController;
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    RespondGeneration respondGeneration;

    private bool showTip = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hammer")
        {
            if (showTip)
            {
                uiController.Notify("tip2", false);
                uiController.Notify("tip3", true);
                respondGeneration.outputSentences = "Hi, I'm you therapist. What can I help you with today?";
                showTip = false;
            }
            characterController.Notify("movement", "up");
            audioSource.Play();
        }
    }

    public void Reset()
    {
        showTip = true;
    }
}
