using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource hitSound;
	private AudioSource hitSoundIns;
    public AudioSource jumpSound;
    private AudioSource jumpSoundIns;
	// Use this for initialization
	public static SoundManager instance;

	void Start () {
		if (SoundManager.instance == null)
			SoundManager.instance = this;
		hitSoundIns = Instantiate(hitSound);
        jumpSoundIns = Instantiate(jumpSound);
	}
	public void PlayHitSound(){
		hitSoundIns.Play();
	}
    public void PlayJumpSound()
    {
        jumpSoundIns.Play();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
