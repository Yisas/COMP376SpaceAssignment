using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}
}
