using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

	public GameObject powerupDrop;

    private ArrayList enemies = new ArrayList();

    private int numOfEnemies;
    private bool powerupDropped = false;

    // Use this for initialization
    void Start () {
        // Setup references
        // Get all enemies in this formation
        foreach (GameObject enemy in AuxFunctions.FindChildrenWithTag(transform, "Enemy"))
            enemies.Add(enemy);

        // Setup variables
        numOfEnemies = enemies.Count;
	}

    // To be called by the enemy when it has died
	public void EnemyDied(Vector3 enemyPosition)
    {
        numOfEnemies--;
		if (numOfEnemies <= 0) {
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
