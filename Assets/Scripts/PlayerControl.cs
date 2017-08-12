using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float speed;
	public float _Attack;
	private Animator anim;

    
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("left"))
        {
            transform.Translate(Vector2.left * speed);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector2.right * speed);
        }
		if (Input.GetKeyDown(KeyCode.Z) || Input.GetKey(KeyCode.Z)) {
			anim.SetFloat ("_Attack", 1);
		}
		if(Input.GetKeyUp (KeyCode.Z))
			{
			anim.SetFloat ("_Attack", 0);
   			 }
	}
			}