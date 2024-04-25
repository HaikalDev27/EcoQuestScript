using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAroundBehaviour : MonoBehaviour
{
    public float moveSpeed = 3f; // Kecepatan berjalan
    public Transform[] waypoints; // Titik-titik untuk bergerak
    private int currentWaypoint = 0; // Indeks waypoint saat ini
    private SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Pergerakan menuju waypoint saat ini
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);
        
        // Jika mencapai waypoint, pindah ke waypoint berikutnya
        if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        if(rb.velocity.x > -1){
            spriteRenderer.flipX = true;
        } else  {
            spriteRenderer.flipX = false;
        }
    }
}
