using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int powerups;
    public int maxNumberOfPickups;

    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        playerController = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Damage is an optional parameter, averageDamageAmount = 10 by default
	public void TakeDamage(int damage = 1){
		powerups -= damage;

        powerups = Mathf.Clamp(powerups, -1, maxNumberOfPickups);

        if (powerups < 0)
            Die();
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

    }
}
