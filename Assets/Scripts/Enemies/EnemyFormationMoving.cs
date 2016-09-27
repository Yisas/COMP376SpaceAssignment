using UnityEngine;
using System.Collections;

public class EnemyFormationMoving : EnemyFormation {

    public float speed;

	// Use this for initialization
	new void Start () {
        base.Start();

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);   
	}
}
