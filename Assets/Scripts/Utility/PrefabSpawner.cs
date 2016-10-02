using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
// Editor specific code here
using UnityEditor;
#endif

public class PrefabSpawner : MonoBehaviour {

	public GameObject parent;
	public GameObject prefab;
    public bool spawnOnAwake = true;
    public float spawnDelay;

    private float spawnTimer;

	void Awake()
	{
        if (spawnOnAwake)
            Spawn();
        else
            spawnTimer = spawnDelay;
	}

    void Update()
    {
        if (!spawnOnAwake)
        {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0)
            {
                Spawn();

                // Stop checking on update
                spawnOnAwake = true;
            }
        }
    }

    private void Spawn()
    {
        Object go;
        GameObject temp;

        if (parent)
        {
            go = Instantiate(prefab, parent.transform);
            temp = (GameObject)go;
            temp.transform.position = transform.position;

        }
        else
            go = Instantiate(prefab, transform.position, transform.rotation);

        temp = (GameObject)go;
        temp.transform.localScale = transform.localScale;

        Destroy(gameObject);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PrefabSpawner))]
public class PrefabSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var PrefabSpawner = target as PrefabSpawner;

        PrefabSpawner.parent = (GameObject) EditorGUILayout.ObjectField("Parent:", PrefabSpawner.parent, typeof(GameObject), true);
        PrefabSpawner.prefab = (GameObject)EditorGUILayout.ObjectField("Prefab:", PrefabSpawner.prefab, typeof(GameObject), true);
        PrefabSpawner.spawnOnAwake = GUILayout.Toggle(PrefabSpawner.spawnOnAwake, "Spawn on Awake:");

        if (!PrefabSpawner.spawnOnAwake)
            PrefabSpawner.spawnDelay = EditorGUILayout.FloatField("Spawn Delay", PrefabSpawner.spawnDelay);

    }
}
#endif
