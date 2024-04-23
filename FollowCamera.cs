using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform targets;
	[Range(1, 10)]
	public float SmoothSpeed;
	public Vector3 offset;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
	
		Vector3 targetPosition = targets.position + offset;
		Vector3 smoothPosition = Vector3.Lerp (transform.position, targetPosition, SmoothSpeed * Time.fixedDeltaTime);
		transform.position = smoothPosition;
	
        
    }
}
