using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    public float parallaxSpeed = 0.1f; // Kecepatan pergerakan paralaks

    private Vector2 startPosition; // Posisi awal latar belakang

    void Start()
    {
        startPosition = transform.position; // Simpan posisi awal latar belakang
    }

    void Update()
    {
        // Hitung pergerakan paralaks berdasarkan waktu
        float parallaxOffset = Time.time * parallaxSpeed;

        // Atur posisi latar belakang berdasarkan offset paralaks
        Vector2 newPosition = startPosition + Vector2.right * parallaxOffset;

        // Terapkan posisi baru ke latar belakang
        transform.position = newPosition;
    }
}
