using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public bool buttonPressed = false;
    // Function that's called when the UI is clicked
    public void OnButtonClick()
    {
        buttonPressed = true;
        Debug.LogWarning("Error woy!! Udah tidur ae sono goblok");
        Invoke("stopPressed", 0.1f);
    }

    void stopPressed(){
        buttonPressed = false;
    }
}

