using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public int maxNumberOfEnemyFormations;
    public int numberOfEnemyFormations;

    public float bossAppearanceInterval;
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToActivate;

    private float bossAppearanceTimer;
    private bool bossAppeared = false;

    void Start()
    {
        // Setup variables
        bossAppearanceTimer = bossAppearanceInterval;
    }

    void Update()
    {
        if (!bossAppeared)
        {
            bossAppearanceTimer -= Time.deltaTime;

            if (bossAppearanceTimer <= 0)
            {
                foreach (GameObject go in objectsToDeactivate)
                    go.SetActive(false);

                foreach (GameObject go in objectsToActivate)
                    go.SetActive(true);

                bossAppeared = true;
            }
        }
    }

}
