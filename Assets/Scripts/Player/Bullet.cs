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
            col.gameObject.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}
