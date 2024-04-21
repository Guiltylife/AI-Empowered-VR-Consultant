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
    MeshRenderer bodyMeshRenderer;
    [SerializeField]
    MeshRenderer eyeMeshRenderer;
    [SerializeField]
    MeshRenderer lightMeshRenderer;
    [SerializeField]
    Material[] bodyMaterials;
    [SerializeField]
    Material[] eyeMaterials;
    [SerializeField]
    Material[] lightMaterials;

    private bool isActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Notify(string type, string text="")
    {
        if (type == "movement")
        {
            movement(text);
        }
        else if (type == "start record")
        {
            if (isActive) speechRecognition.StartRecording();
        }
        else if (type == "stop record")
        {
            if (isActive)
            {
                speechRecognition.StopRecording();
            }
        }
        else if (type == "state")
        {
            changeState(text);
        }
        else if (type == "reset") {
            movement("reset");
            isActive = false;
        }
        else
        {
            Debug.LogWarning("Unknow type!!!");
        }
    }

    private void movement(string text)
    {
        if (text == "up")
        {
            animator.SetTrigger("Up");
            isActive = true;
        }
        else if (text == "down")
        {
            animator.SetTrigger("Down");
            isActive = false;
        }
        else if (text == "reset")
        {
            animator.SetTrigger("Reset");
            isActive = false;
        }
        else
        {
            Debug.Log("Unknow movement!!!");
        }
    }

    private void changeState(string state)
    {
        if (state == "idle")
        {
            bodyMeshRenderer.material = bodyMaterials[0];
            eyeMeshRenderer.material = eyeMaterials[0];
            lightMeshRenderer.material = lightMaterials[0];
        }
        else if (state == "think")
        {
            bodyMeshRenderer.material = bodyMaterials[1];
            eyeMeshRenderer.material = eyeMaterials[1];
            lightMeshRenderer.material = lightMaterials[1];
        }
        else if (state == "speak")
        {
            bodyMeshRenderer.material = bodyMaterials[2];
            eyeMeshRenderer.material = eyeMaterials[2];
            lightMeshRenderer.material = lightMaterials[2];
        }
        else
        {
            Debug.LogWarning("Unknow state!!!");
        }
    }
}
