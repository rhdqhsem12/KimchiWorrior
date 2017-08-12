using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float speed;
	private Animator anim;
    private PolygonCollider2D ccd;

    
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
        ccd = transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>();
        ccd.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector2.left * speed);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector2.right * speed);
        }

        anim.SetBool("isAttack", Input.GetKeyDown(KeyCode.Z));

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack"))
        {
            ccd.enabled = true;
		}
        else
        {
            ccd.enabled = false;
        }
	}
}