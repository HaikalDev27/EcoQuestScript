using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    // Fungsi yang dipanggil saat tombol UI di klik
    public void OnButtonClick()
    {
        Input.GetKeyDown(KeyCode.F);
        Debug.LogWarning("Error woy!! Udah tidur ae sono goblok");
    }
}

