using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public int armHitsToOpenCore;

    public GameObject hitEffect;
    public GameObject beam;

    private Animator animator;
    private Transform beamSpawn;

    private int armHits = 0;
    private bool coreIsOpen = false;

	// Use this for initialization
	void Start () {
        // Set up references
        animator = GetComponent<Animator>();
        beamSpawn = transform.FindChild("beamSpawn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // One of the arms is hit by a bullet
    public void ArmHit(GameObject armHit, Vector3 position)
    {
        armHits++;

        armHit.GetComponent<Animator>().SetTrigger("Hit");

        if (armHits >= armHitsToOpenCore)
        {
            armHits = 0;

            Instantiate(hitEffect, position, new Quaternion(0, 0, 0, 0));

            OpenCore();
        }
    }

    void OpenCore()
    {
        //TODO
        if (!coreIsOpen)
        {
            animator.SetTrigger("open");

            coreIsOpen = true;
        }
    }

    public void ShootFromCore()
    {
        // TODO
        Instantiate(beam, beamSpawn.position, beamSpawn.rotation);
    }

    // Invulnerable part of the boss is hit (so basically just instantiate explosion)
    public void BodyHit(Vector3 position)
    {
        Instantiate(hitEffect, position, new Quaternion(0, 0, 0, 0));
    }
}
