using UnityEngine;
using System.Collections;

public class DestroyAfterTimer : MonoBehaviour {

	public float destroyInterval;

	private float destroyTimer;

	// Use this for initialization
	void Start () {
		destroyTimer = destroyInterval;
	}
	
	// Update is called once per frame
	void Update () {
		destroyTimer -= Time.deltaTime;
		if (destroyTimer <= 0)
			Destroy (gameObject);
	}
}
