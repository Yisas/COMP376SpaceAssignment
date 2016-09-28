using UnityEngine;
using System.Collections;

public class RayBeam : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().Die();
        }
    }
}
