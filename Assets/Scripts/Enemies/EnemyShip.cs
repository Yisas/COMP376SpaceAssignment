using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

    public float speed;

	public GameObject deathEffect;
    public AudioClip[] deathAudio;

    private Rigidbody2D rb;
    private EnemyFormation enemyFormation;
    private AudioSource audioSource;

    private bool hitByPlayer = false;                   // Whether this ship has been hit by a player

    // Use this for initialization
    void Start () {
        // Set up refereces
        rb = GetComponent<Rigidbody2D>();
        enemyFormation = GetComponentInParent<EnemyFormation>();
        audioSource = GameObject.FindGameObjectWithTag("MainAudioSource").GetComponent<AudioSource>();

        // Set speed at start
        rb.velocity = new Vector2(0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    // To be called when hit by an enemy bullet
    public void HitByPlayer()
    {
		Instantiate (deathEffect, transform.position, transform.rotation);
        hitByPlayer = true;
        PlayerDeathAudioClip();
        Destroy(gameObject);
    }

	// To be called when the enemy hits the player
	void HittingPlayer(){
		Instantiate (deathEffect, transform.position, transform.rotation);
        PlayerDeathAudioClip();
        Destroy(gameObject);
	}

	void OnDestroy(){
        enemyFormation.EnemyDied(transform.position, hitByPlayer);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			col.gameObject.GetComponent<PlayerHealth> ().TakeDamage ();
			HittingPlayer ();
		}
	}

    private void PlayerDeathAudioClip()
    {
        audioSource.PlayOneShot(deathAudio[Random.Range(0, deathAudio.Length)]);
    }
}
