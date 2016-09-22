using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	private float horizontalInput = 0;			// Magnitude of horizontal input coming from the input axis
	private float verticalInput = 0;			// Magnitude of vertical input coming from the input axis

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		// Set up references
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		CollectInput ();
	}

	// FixedUpdate is called every fixed framerate frame
	void FixedUpdate(){
		Vector2 moveForce = new Vector2 (horizontalInput, verticalInput) * speed;
		rb.AddForce (moveForce);
		ConstrainPosition ();
	}

	private void CollectInput(){
		horizontalInput = Input.GetAxis ("Horizontal");
		verticalInput = Input.GetAxis ("Vertical");
	}

	private void ConstrainPosition(){
		rb.position = new Vector2 (
			Mathf.Clamp (rb.position.x, xMin, xMax),
			Mathf.Clamp (rb.position.y, yMin, yMax)
		);
	}
}
