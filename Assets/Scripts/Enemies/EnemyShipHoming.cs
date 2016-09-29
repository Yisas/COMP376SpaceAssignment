using UnityEngine;
using System.Collections;

public class EnemyShipHoming : EnemyShip {

    public float horizontalSpeed;
    public float turnSpeed;

    public float initialExitForce;
    public int initialForceDirection;
    public float initialForceInterval;                   // Time interval before starting to apply velocity towards the player. For cosmetic effect

    private GameObject player;

    private int directionSign = 0;                      // Direction sign of relative position to the player. Positive 1 is to the right
    private float initialForceTimer;

    new void Start()
    {
        base.Start();

        // Set up references
        player = GameObject.FindGameObjectWithTag("Player");

        // Set up variables
        initialForceTimer = initialForceInterval;
        
        rb.AddForce(new Vector2(initialExitForce * initialForceDirection, 0));
    }

    // Update is called once per frame
    new void Update()
    {
        initialForceTimer -= Time.deltaTime;

        base.Update();


        if (initialForceTimer <= 0)
        {
            directionSign = FindPlayer();

            // Set the enemy's velocity to moveSpeed in the x direction.
            rb.velocity = new Vector2(speed * directionSign, GetComponent<Rigidbody2D>().velocity.y);
            LookAtPlayer();
        }
    }

    // Uses horizontal position diference to return the sign of the offset to the player.
    protected int FindPlayer()
    {
        int direction = 0;

        Vector3 tempFloat = transform.position - player.transform.position;

        if (tempFloat.x <= 0)
            direction = 1;
        else
            direction = -1;

        return direction;
    }

    void LookAtPlayer()
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnSpeed);
        
    }
}
