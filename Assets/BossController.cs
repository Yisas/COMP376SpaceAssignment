using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

    public int armHitsToOpenCore;

    private int armHits = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ArmHit()
    {
        armHits++;

        if(armHits >= armHitsToOpenCore)
        {
            armHits = 0;

            OpenCore();
        }
    }

    void OpenCore()
    {
        //TODO
    }
}
