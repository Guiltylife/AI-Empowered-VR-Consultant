using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muyu : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    AudioSource audioSource;
    
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
            characterController.Notify("movement", "up");
            audioSource.Play();
        }
    }
}
