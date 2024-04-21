using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSynthesis : MonoBehaviour
{
    [SerializeField] RespondGeneration respondGeneration;
    [SerializeField] AudioSource audioSource;
    [SerializeField] string voice;
    [SerializeField] CharacterController characterController;
    [SerializeField] UIController uiController;

    private LMNT.LMNTSpeech speech;
    private int state = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (respondGeneration.outputSentences != "")
        {
            if (respondGeneration.outputSentences == "waiting")
            {
                state = 0;

                Reset();
            } else
            {
                state = 1;
                
                if (speech) Reset();

                speech = gameObject.AddComponent<LMNT.LMNTSpeech>();
                speech.voice = voice;
                speech.dialogue = respondGeneration.outputSentences;
                respondGeneration.outputSentences = "";
                StartCoroutine(speech.Talk());
            }
        }

        if (state == 1 && audioSource.isPlaying)
        {
            state = 2;
            characterController.Notify("state", "speak");
            uiController.Notify("thinking", false);
        }

        if (state == 2 && !audioSource.isPlaying)
        {
            state = 0;
            characterController.Notify("state", "idle");
        }
    }

    public void Reset()
    {
        audioSource.Stop();
        audioSource.clip = null;
        Destroy(speech);
    }
}
