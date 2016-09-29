using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerHoming : EnemySpawnerStatic
{
	public int spawnDirection;
	
    public override void Spawn()
    {
        // Final instantiation
        enemies[nextEnemyIndex].GetComponent<EnemyShipHoming>().initialForceDirection = spawnDirection;

        GameObject enemy = (GameObject)Instantiate(enemies[nextEnemyIndex], transform.position, transform.rotation);
    }
}
