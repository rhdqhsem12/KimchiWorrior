using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource hitSound;
	private AudioSource hitSoundObj;
	// Use this for initialization
	public static SoundManager instance;

	void Start () {
		if (SoundManager.instance == null)
			SoundManager.instance = this;
		hitSoundObj = Instantiate (hitSound);
	}
	public void PlaySound(){
		hitSoundObj.Play();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
