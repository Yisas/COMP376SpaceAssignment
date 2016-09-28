using UnityEngine;
using System.Collections;

public class AuxAnimatorComunicator : MonoBehaviour {

	public void ShootFromCore()
    {
        transform.parent.GetComponent<BossController>().ShootFromCore();
    }

}
