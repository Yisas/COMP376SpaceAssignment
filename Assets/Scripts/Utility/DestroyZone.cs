using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour {

    void Start()
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}
}
