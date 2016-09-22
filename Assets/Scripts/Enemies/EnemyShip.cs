using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;
    private EnemyFormation enemyFormation;

    // Use this for initialization
    void Start () {
        // Set up refereces
        rb = GetComponent<Rigidbody2D>();
        enemyFormation = GetComponentInParent<EnemyFormation>();

        // Set speed at start
        rb.velocity = new Vector2(0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    // To be called when hit by an enemy bullet
    public void Hit()
    {
        enemyFormation.EnemyDied();
        Destroy(gameObject);
    }
}
