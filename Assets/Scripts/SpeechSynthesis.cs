using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSynthesis : MonoBehaviour
{
    [SerializeField] RespondGeneration respondGeneration;
    [SerializeField] AudioSource audioSource;
    [SerializeField] string voice;
    private LMNT.LMNTSpeech speech;
    
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
                audioSource.Stop();
                audioSource.clip = null;
                Destroy(speech);
            } else
            {
                if (speech)
                {
                    audioSource.Stop();
                    audioSource.clip = null;
                    Destroy(speech);
                }
                speech = gameObject.AddComponent<LMNT.LMNTSpeech>();
                speech.voice = voice;
                speech.dialogue = respondGeneration.outputSentences;
                respondGeneration.outputSentences = "";
                StartCoroutine(speech.Talk());
            }
        }
    }
}
