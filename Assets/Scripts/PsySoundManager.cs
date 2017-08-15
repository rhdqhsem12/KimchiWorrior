using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsySoundManager : MonoBehaviour {
	public AudioSource hitSound;
	private AudioSource hitSoundIns;
    public AudioSource jumpSound;
    private AudioSource jumpSoundIns;
	// Use this for initialization
	public static PsySoundManager instance;

	void Start () {
		if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
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
