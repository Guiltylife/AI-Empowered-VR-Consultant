using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject title;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject tip1;
    [SerializeField]
    GameObject tip2;
    [SerializeField]
    GameObject tip3;
    [SerializeField]
    GameObject tip4;
    [SerializeField]
    GameObject error1;
    [SerializeField]
    GameObject thinking;

    public void Notify(string name, bool enable=false)
    {
        if (name == "title")
        {
            title.SetActive(enable);
        }
        else if (name == "pauseMenu")
        {
            pauseMenu.SetActive(enable);
        }
        else if (name == "tip1")
        {
            tip1.SetActive(enable);
        }
        else if (name == "tip2")
        {
            tip2.SetActive(enable);
        }
        else if (name == "tip3")
        {
            tip3.SetActive(enable);
        }
        else if (name == "tip4")
        {
            tip4.SetActive(enable);
        }
        else if (name == "error1")
        {
            error1.SetActive(enable);
        }
        else if (name == "thinking")
        {
            thinking.SetActive(enable);
        }
        else if (name == "reset") {
            title.SetActive(false);
            pauseMenu.SetActive(false);
            tip1.SetActive(false);
            tip2.SetActive(false);
            tip3.SetActive(false);
            tip4.SetActive(false);
            error1.SetActive(false);
            thinking.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Unknow UI name!!!");
        }
    }
}
