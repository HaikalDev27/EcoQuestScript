using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAroundBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan terbang
    public float changeDirectionTime = 3f; // Waktu antara perubahan arah
    private Vector2 currentDirection; // Arah terbang saat ini
    private float timer = 0f;

    void Start()
    {
        // Randomize arah terbang awal
        currentDirection = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Pergerakan sesuai arah terbang saat ini
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);

        // Mengubah arah setelah waktu tertentu
        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            currentDirection = Random.insideUnitCircle.normalized;
            timer = 0f;
        }
    }
}
