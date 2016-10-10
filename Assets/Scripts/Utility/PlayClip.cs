using UnityEngine;
using System.Collections;

public class PlayClip : MonoBehaviour {

	public AudioClip audioClip;

	public void PlayAClip(){
		GetComponent<AudioSource> ().PlayOneShot (audioClip);
	}
}
