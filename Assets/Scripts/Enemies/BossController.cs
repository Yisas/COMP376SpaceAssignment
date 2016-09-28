using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public int armHitsToOpenCore;

    public GameObject hitEffect;
    public GameObject beam;

    private Animator animator;
    private Transform beamSpawn;
    private GameObject beamCharge;

    private int armHits = 0;
    private bool coreIsOpen = false;

	// Use this for initialization
	void Start () {
        // Set up references
        animator = GetComponent<Animator>();
        beamCharge = transform.FindChild("Ray Charge").gameObject;
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
            animator.SetTrigger("open");

            coreIsOpen = true;
    }

    void CloseCore()
    {
        animator.SetTrigger("close");

       coreIsOpen = false;
    }

    public void ChargeShotFromCore()
    {
        beamCharge.GetComponent<Animator>().SetTrigger("charge");
    }

    public void ShootFromCore()
    {
        // TODO
        Instantiate(beam, beamSpawn.position, beamSpawn.rotation);
        CloseCore();
    }

    // Invulnerable part of the boss is hit (so basically just instantiate explosion)
    public void BodyHit(Vector3 position)
    {
        Instantiate(hitEffect, position, new Quaternion(0, 0, 0, 0));
    }
}
