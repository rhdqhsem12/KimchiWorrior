using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float speed;
    public float jumpSpeed;
    public float gravity;
    private float ySpeed = 0;
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

        if (Input.GetKey("up") && !anim.GetBool("isJumping"))
        {
            ySpeed = jumpSpeed;
            SoundManager.instance.PlayJumpSound();
            anim.SetBool("isJumping", true);
        }

        if (anim.GetBool("isJumping"))
        {
            transform.Translate(Vector2.up * ySpeed);
            ySpeed -= gravity;
        }

        if (transform.position.y < -2.3)
        {
            float x = transform.position.x;
            transform.position = new Vector2(x, (float)-2.3);
            anim.SetBool("isJumping", false);
        }

        bool isAttacked = Input.GetKeyDown(KeyCode.Z);
        if (isAttacked && !anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack"))
            SoundManager.instance.PlayHitSound();
        anim.SetBool("isAttack", isAttacked);
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