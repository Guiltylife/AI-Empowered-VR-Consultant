using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    Material skybox_morning;
    [SerializeField]
    Material skybox_dusk;
    [SerializeField]
    Material skybox_night;
    [SerializeField]
    GameObject waterDaytime;
    [SerializeField]
    GameObject waterNightime;

    private bool skyIsSet = false;
    
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
        if (type == "sky")
        {
            if (!skyIsSet)
            {
                changeSky(text);
                skyIsSet = true;
            }
        }
        else if (type == "reset")
        {
            skyIsSet = false;
            changeSky("morning");
        }
        else
        {
            Debug.LogWarning("Unknow type!!!");
        }
    }

    private void changeSky(string time)
    {
        if (time == "morning")
        {
            RenderSettings.skybox = skybox_morning;
            waterDaytime.SetActive(true);
            waterNightime.SetActive(false);
        } else if (time == "dusk")
        {
            RenderSettings.skybox = skybox_dusk;
            waterDaytime.SetActive(true);
            waterNightime.SetActive(false);
        } else if (time == "evening")
        {
            RenderSettings.skybox = skybox_night;
            waterDaytime.SetActive(false);
            waterNightime.SetActive(true);
        } else
        {
            Debug.LogWarning("Unknow time!!!");
        }
    }
}
