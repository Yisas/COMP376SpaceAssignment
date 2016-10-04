using UnityEngine;
using System.Collections;

public class BulletHellRespawner : MonoBehaviour {

    private Transform player;

    private Transform bottom;

	// Use this for initialization
	void Start () {
        // Setup references
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bottom = transform.FindChild("Bottom");
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Bullet")
        {
            if (col.transform.rotation.eulerAngles.z == 0)
                col.transform.position = new Vector3(col.transform.position.x, bottom.position.y, col.transform.position.z);
            else
            {
                float horizontalOffset = (col.transform.position.y + Mathf.Abs(bottom.position.y)) / Mathf.Tan(Mathf.Deg2Rad * (90 - col.transform.rotation.eulerAngles.z));
                Vector3 pos = new Vector3(col.transform.position.x + horizontalOffset, bottom.position.y, col.transform.position.z);
                col.transform.position = pos;
            }

			col.GetComponent<Bullet> ().Respawned ();
        }
    }
}
