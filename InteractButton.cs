using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public bool buttonPressed = false;
    // Fungsi yang dipanggil saat tombol UI di klik
    public void OnButtonClick()
    {
        buttonPressed = true;
        Debug.LogWarning("Error woy!! Udah tidur ae sono goblok");
    }
}

