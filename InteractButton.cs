using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    public Interactable interactableScript; 
    private void Start()
    {
        // Cari skrip yang mengatur interaksi dengan objek jika belum ada
        if (interactableScript == null)
        {
            interactableScript = FindObjectOfType<Interactable>();
        }
    }

    // Fungsi yang dipanggil saat tombol UI di klik
    public void OnButtonClick()
    {
        if (interactableScript != null)
        {
            interactableScript.OnInteract();
        }
        else
        {
            Debug.LogWarning("Error woy!! Udah tidur ae sono goblok");
        }
    }
}

