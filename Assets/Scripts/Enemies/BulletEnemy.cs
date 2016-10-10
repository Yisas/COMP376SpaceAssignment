using UnityEngine;
using System.Collections;

public class BulletEnemy : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){

		if (col.transform.tag == "Player") 
		{
			col.GetComponent<PlayerHealth> ().TakeDamage ();
			Destroy (gameObject);
		}

	}
}
