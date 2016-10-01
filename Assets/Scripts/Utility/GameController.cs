using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public enum GameMode { Normal = 0, BulletHell = 1 };

    public int maxNumberOfEnemyFormations;
    public int numberOfEnemyFormations;

    public float bossAppearanceInterval;
    public GameObject[] bulletHellActiveObjects;
    public GameObject[] objectsToDeactivate;
    public GameObject[] objectsToActivate;

    private static GameMode gameMode = GameMode.Normal;

    private float bossAppearanceTimer;
    private bool bossAppeared = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        // Setup variables
        bossAppearanceTimer = bossAppearanceInterval;

        // Turn on bullet hell mode objects
        if (gameMode == GameMode.BulletHell)
        {
            // Bullets hit the player in bullet hell mode
            Bullet.hitsPlayer = true;

            foreach (GameObject go in bulletHellActiveObjects)
                go.SetActive(true);
        }
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

    public void SetGameMode(int mode)
    {
        gameMode = (GameMode) mode;
    }
}
