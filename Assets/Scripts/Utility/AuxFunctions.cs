using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AuxFunctions : MonoBehaviour {

	public static ArrayList FindChildrenWithTag(Transform parentTransform, string tag){
		ArrayList gos = new ArrayList();

		foreach (Transform tf in parentTransform) {
			if (tf.gameObject.tag == tag) {
				gos.Add(tf.gameObject);
			}
		}

		return gos;
	}

	public static GameObject[]  FindGameObjectsWithLayer (LayerMask layer) {
		GameObject[] goArray = FindObjectsOfType<GameObject>();
		List<GameObject> goList = new List<GameObject> ();
		for (int i = 0; i < goArray.Length; i++) {
			if (goArray[i].layer == layer) {
				goList.Add(goArray[i]);
			}
		}
		if (goList.Count == 0) {
			return null;
		}
		return goList.ToArray();
	}
}
