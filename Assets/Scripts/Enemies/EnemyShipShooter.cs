using UnityEngine;
using System.Collections;

public class EnemyShipShooter : EnemyShip {

	public GameObject bullet;
	public float shotForce;
	public float intervalBetweenShots;

	private Transform shotSpawn;

	private float shotTimer;						// Countdown to when the enemy is allowed to shoot again

	new void Start()
	{
		base.Start ();

		// Setup references
		shotSpawn = transform.FindChild ("shotSpawn");
	}

	new void Update()
	{
		base.Update ();
		shotTimer -= Time.deltaTime;
	}


	new void FixedUpdate(){
		base.FixedUpdate ();

		RaycastHit2D hit = Physics2D.Raycast(shotSpawn.position, -Vector2.up);

		if (hit.collider != null) {
			if (hit.collider.tag == "Player") {
				Shoot ();
			}
		}
	}

	private void Shoot()
	{
		if (shotTimer <= 0 && transform.position.y >= 0) {
				GameObject tempBullet = (GameObject)Instantiate (bullet, shotSpawn.transform.position, bullet.transform.rotation);
				tempBullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -shotForce);

				shotTimer = intervalBetweenShots;
			} 
	}
}
