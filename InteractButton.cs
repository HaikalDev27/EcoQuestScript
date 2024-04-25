using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InteractButton : MonoBehaviour
{
    public bool isClicked;
    // Fungsi yang dipanggil saat tombol UI di klik
    public void OnButtonClick()
    {
        isClicked = true;
        Input.GetKeyDown(KeyCode.F);
        Debug.LogWarning("Error woy!! Udah tidur ae sono goblok");
    }
}

