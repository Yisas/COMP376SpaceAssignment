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

        if (powerups < 0)
            Die();
	}

    void PickupPowerup()
    {
        powerups += 1;

        Mathf.Clamp(powerups, 0, maxNumberOfPickups);

        playerController.numberOfShots++;
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
