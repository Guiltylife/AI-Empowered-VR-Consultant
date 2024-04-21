using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField]
    UIController uiController;

    private bool showTip = true;

    public void OnGrasp()
    {
        if (showTip)
        {
            showTip = false;
            uiController.Notify("tip1", false);
            uiController.Notify("tip2", true);
        }
    }

    public void Reset()
    {
        showTip = true;
        transform.localPosition = new Vector3(0.1f, 0.4f, 2);
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
}
