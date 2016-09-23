using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
