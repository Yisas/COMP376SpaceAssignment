using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerStatic : MonoBehaviour
{
	public float spawnTime;
	// The amount of time between each spawn.
	public float spawnDelay;
	// The amount of time before spawning starts.
	public GameObject[] enemies;
	// Array of enemy prefabs.

    private GameController gameController;

	private float spawnTimer;
	private int nextEnemyIndex;

	void Awake ()
	{
        // Setup references
        gameController = GameObject.FindObjectOfType<GameController>();

        // Setup variables
		spawnTimer = spawnTime;
	}

	void Update ()
	{
		// Waiting for delay
		if (spawnDelay > 0)
			spawnDelay -= Time.deltaTime;
		// Else start spawning.
		else {
			// Check for spawnTimer
			if (spawnTimer <= 0 && gameController.numberOfEnemyFormations < gameController.maxNumberOfEnemyFormations) {
				// Chose enemy type to spawn
				nextEnemyIndex = Random.Range (0, enemies.Length);

				// Final instantiation
				GameObject enemy = (GameObject)Instantiate (enemies [nextEnemyIndex], transform.position, transform.rotation);

				gameController.numberOfEnemyFormations++;

				// Reset timer and flags
				spawnTimer = spawnTime;
			}
			spawnTimer -= Time.deltaTime;
		}
	}
}
