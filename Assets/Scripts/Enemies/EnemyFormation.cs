using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

	public GameObject powerupDrop;

    private ArrayList enemies = new ArrayList();

    private int initialNumOfEnemies;
    private int numOfEnemies;
    private int enemiesKilledByPlayer = 0;                  // How many ships where destroyed by the player.
    private bool powerupDropped = false;

    // Use this for initialization
    void Start () {
        // Setup references
        // Get all enemies in this formation
        foreach (GameObject enemy in AuxFunctions.FindChildrenWithTag(transform, "Enemy"))
            enemies.Add(enemy);

        // Setup variables
        numOfEnemies = enemies.Count;
        initialNumOfEnemies = enemies.Count;
    }

    // To be called by the enemy when it has died
	public void EnemyDied(Vector3 enemyPosition, bool hitByPlayer)
    {
        numOfEnemies--;

        if (hitByPlayer)
            enemiesKilledByPlayer++;

        // If all players are dead, destroy formation object
		if (numOfEnemies <= 0) {
            // If all enemies where killed by player, drop powerup
            if(enemiesKilledByPlayer == initialNumOfEnemies)
			    DropPowerUp (enemyPosition);

			Destroy (gameObject);
		}
    }
	
	// Update is called once per frame
	void Update () {
    }

	void DropPowerUp(Vector3 enemyPosition)
    {
        // TODO
        if (!powerupDropped)
        {
            powerupDropped = true;
			Instantiate (powerupDrop, enemyPosition, powerupDrop.transform.rotation);
        }
    }
}
