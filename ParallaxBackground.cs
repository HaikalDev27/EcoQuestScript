using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	private float length, startpos;
	public GameObject cam;
	public float parallaxSpeed;

	// Use this for initialization
	void Start () {
		startpos = transform.position.x;
		length = GetComponent<SpriteRenderer> ().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		float dist = (cam.transform.position.x * parallaxSpeed);

		transform.position = new Vector3 (startpos + dist, transform.position.y, transform.position.z);
	}
}
