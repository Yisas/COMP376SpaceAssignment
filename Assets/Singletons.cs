using UnityEngine;
using System.Collections;

public class Singletons : MonoBehaviour {

	static private AudioSource mainGameAudio;
	static private GameObject gameController;

	void Awake()
	{
		if (GetComponent<AudioSource> ()) 
		{
			if (mainGameAudio)
				Destroy (gameObject);
			else
				mainGameAudio = GetComponent<AudioSource> ();
		}

		if (GetComponent<GameController> ()) 
		{
			if (gameController)
				Destroy (gameObject);
			else
				gameController = gameObject;
		}
	}
}
