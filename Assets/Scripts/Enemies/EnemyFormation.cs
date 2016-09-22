using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

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
    public void EnemyDied()
    {
        numOfEnemies--;
    }
	
	// Update is called once per frame
	void Update () {
        if (numOfEnemies <= 0)
            DropPowerUp();

    }

    void DropPowerUp()
    {
        // TODO
        if (!powerupDropped)
        {
            powerupDropped = true;
            Debug.Log("drop power up");
        }
    }
}
