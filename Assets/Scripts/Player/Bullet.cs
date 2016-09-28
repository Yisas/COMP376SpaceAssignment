using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Enemy")
        {
            col.gameObject.GetComponentInParent<EnemyShip>().HitByPlayer();
        }

        if(col.transform.tag == "BossArm")
        {
            col.transform.parent.transform.parent.GetComponent<BossController>().ArmHit(col.gameObject, transform.FindChild("bulletTop").transform.position);
        }

        if (col.transform.tag == "BossInvulnerable")
        {
            col.transform.parent.transform.parent.GetComponent<BossController>().BodyHit(transform.FindChild("bulletTop").transform.position);
        }

        if(col.transform.tag == "BossWeakSpot")
        {
            col.transform.parent.GetComponent<BossController>().WeakSpotHit();
        }

        Destroy(gameObject);
    }
}
