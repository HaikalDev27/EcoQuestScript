using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingBehaviour : MonoBehaviour
{
    public Transform tree; // Referensi ke pohon atau objek tempat hewan bersembunyi
    public float gossipTimeMin = 5f; // Waktu minimum antara mengumpat
    public float gossipTimeMax = 10f; // Waktu maksimum antara mengumpat
    private bool isGossiping = false; // Status apakah sedang mengumpat
    private float gossipTimer = 0f; // Timer untuk mengumpat
    private Animator animator; // Animator untuk animasi hewan

    void Start()
    {
        animator = GetComponent<Animator>();

        // Mulai mengumpat secara acak setelah waktu tertentu
        gossipTimer = Random.Range(gossipTimeMin, gossipTimeMax);
    }

    void Update()
    {
        // Timer untuk mengumpat secara acak
        gossipTimer -= Time.deltaTime;
        if (gossipTimer <= 0f && !isGossiping)
        {
            StartGossiping();
        }

        // Jika sedang mengumpat, jalankan animasi mengumpat
        if (isGossiping)
        {
            animator.SetBool("IsGossiping", true);
        }
        else
        {
            animator.SetBool("IsGossiping", false);
        }
        
        Invoke("StopGossiping", gossipTimer);
        Invoke("StartGossiping", gossipTimer);
    }

    void StopGossiping()
    {
        Debug.Log("Keluar dari pohon...");
        isGossiping = false;
    }

    // Fungsi untuk memulai mengumpat
    void StartGossiping()
    {
        // Implementasi logika untuk mengumpat di sini
        Debug.Log("Mengumpat di belakang pohon...");
        isGossiping = true;
    }
}
