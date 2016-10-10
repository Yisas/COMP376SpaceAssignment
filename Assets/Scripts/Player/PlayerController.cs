using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	public Object bullet;
	public float shotForce;
	public float minShotInterval;				// Minimum elapsed time between shots
    public int numberOfShots = 0;               // Amount of shots that the player spawns

    public AudioClip[] laserShotAudio;

	private float horizontalInput = 0;			// Magnitude of horizontal input coming from the input axis
	private float verticalInput = 0;			// Magnitude of vertical input coming from the input axis
	private bool shootInput = false;			// Whether the player is shooting this frame

    private GameObject shotSpawns;
    private float shotTimer;

	private Rigidbody2D rb;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		// Set up references
		rb = GetComponent<Rigidbody2D>();
        shotSpawns = transform.FindChild("Shot Spawns").gameObject;
        audioSource = GetComponent<AudioSource>();

		// Set up variables
		shotTimer = minShotInterval;
	}
	
	// Update is called once per frame
	void Update () {
		CollectInput ();

		if (shotTimer >= 0)
			shotTimer -= Time.deltaTime;
	}

	// FixedUpdate is called every fixed framerate frame
	void FixedUpdate(){
		Shoot ();
		Move ();
	}

	private void CollectInput(){
		horizontalInput = Input.GetAxis ("Horizontal");
		verticalInput = Input.GetAxis ("Vertical");

		if(shotTimer < 0)
			shootInput = Input.GetButton ("Fire1");
	}

	private void Shoot(){
		if (shootInput) {

            // Chose the shot spawn configuration
            GameObject shotSpawners = shotSpawns.transform.FindChild("Powerup " + numberOfShots).gameObject;

            GameObject tempBullet;

            foreach (Transform shotSpawn in shotSpawners.transform)
            {
                tempBullet = (GameObject)Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                Vector2 shotVector = new Vector2(0, shotForce);
                shotVector = AuxFunctions.RotateVector2d(shotVector, shotSpawn.eulerAngles.z);
                tempBullet.GetComponent<Rigidbody2D>().velocity = shotVector;
                
            }
			shootInput = false;
			shotTimer = minShotInterval;

            audioSource.PlayOneShot(laserShotAudio[Random.Range(0, laserShotAudio.Length)]);
		}
	}

	private void Move(){
		ConstrainPosition ();
		Vector2 moveForce = new Vector2 (horizontalInput, verticalInput) * speed;
		rb.velocity = moveForce;
		ConstrainPosition ();
	}

	private void ConstrainPosition(){

		// Cancel velocities if hitting borders
		if (rb.position.x < xMin || rb.position.x > xMax)
			rb.velocity = new Vector2(0, rb.velocity.y);

		if (rb.position.y < yMin || rb.position.y > yMax)
			rb.velocity = new Vector2(rb.velocity.x, 0);

		// Clamp positions
		rb.position = new Vector2 (
			Mathf.Clamp (rb.position.x, xMin, xMax),
			Mathf.Clamp (rb.position.y, yMin, yMax)
		);
	}
}
