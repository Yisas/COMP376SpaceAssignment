using UnityEngine;
using System.Collections;

public class AuxFunctions : MonoBehaviour {

	public static ArrayList FindChildrenWithTag(Transform parentTransform, string tag){
		ArrayList gos = new ArrayList();
		int i = 0;

		foreach (Transform tf in parentTransform) {
			if (tf.gameObject.tag == tag) {
				gos.Add(tf.gameObject);
			}
		}

		return gos;
	}
}
