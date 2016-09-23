using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

    public float speed;

	public GameObject deathEffect;

    private Rigidbody2D rb;
    private EnemyFormation enemyFormation;

    // Use this for initialization
    void Start () {
        // Set up refereces
        rb = GetComponent<Rigidbody2D>();
        enemyFormation = GetComponentInParent<EnemyFormation>();

        // Set speed at start
        rb.velocity = new Vector2(0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    // To be called when hit by an enemy bullet
    public void Hit()
    {
		Instantiate (deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

	// To be called when the enemy hits the player
	void HitPlayer(){
		Instantiate (deathEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	void OnDestroy(){
		enemyFormation.EnemyDied (transform.position);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			col.gameObject.GetComponent<PlayerHealth> ().TakeDamage ();
			HitPlayer ();
		}
	}
}
