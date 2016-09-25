using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int powerups;
    public int maxNumberOfPickups;

    public AudioClip deathAudio;

    private PlayerController playerController;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        // Setup references
        playerController = GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Damage is an optional parameter, averageDamageAmount = 10 by default
	public void TakeDamage(int damage = 1){
		powerups -= damage;

        powerups = Mathf.Clamp(powerups, -1, maxNumberOfPickups);

        playerController.numberOfShots--;
        playerController.numberOfShots = Mathf.Clamp(playerController.numberOfShots, 1, maxNumberOfPickups + 1);

        if (powerups < 0)
            Die();
        else
            StartCoroutine(AuxFunctions.ShakeCamera(0.5f,0.5f));
    }

    void PickupPowerup()
    {
        powerups += 1;

        powerups = Mathf.Clamp(powerups, 0, maxNumberOfPickups);

        playerController.numberOfShots++;
        playerController.numberOfShots = Mathf.Clamp(playerController.numberOfShots, 1, maxNumberOfPickups + 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Powerup")
        {
            PickupPowerup();
            Destroy(col.gameObject);
        }
    }

    void Die()
    {
        Rigidbody2D[] rbs = GameObject.FindObjectsOfType<Rigidbody2D>();
        EnemySpawner[] espwnrs = GameObject.FindObjectsOfType<EnemySpawner>();

        foreach (Rigidbody2D rb in rbs)
            rb.velocity = new Vector2(0, 0);

        foreach (EnemySpawner es in espwnrs)
            es.enabled = false;

        GetComponent<Animator>().SetTrigger("death");
        audioSource.PlayOneShot(deathAudio);
        StartCoroutine(AuxFunctions.ShakeCamera(1,3));
    }
}
