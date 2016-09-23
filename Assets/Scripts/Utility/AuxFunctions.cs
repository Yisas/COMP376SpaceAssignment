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

    public static Vector2 RotateVector2d(Vector2 vector, float degrees)
    {

        float rads = Mathf.Deg2Rad * degrees;

        Vector2 returnVector = new Vector2();

        returnVector.x = vector.x * Mathf.Cos(rads) - vector.y * Mathf.Sin(rads);
        returnVector.y = vector.x * Mathf.Sin(rads) + vector.y * Mathf.Cos(rads);

        return returnVector;
    }
}
