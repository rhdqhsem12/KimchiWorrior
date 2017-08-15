using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenjiManager : MonoBehaviour {
    public int hp;
    public float speed;
    public float abst;
    public float jumpSpeed;
    public float gravity;
    private float ySpeed = 0;
    private Animator anim;
    private BoxCollider2D ccd;
    bool isAttacked;
    bool isJumping;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        ccd = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        ccd.enabled = false;
        isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.Find("Player");
        abst = Mathf.Abs(player.transform.position.x - transform.position.x);
        
        if (abst <= 7)
        {
            isAttacked = true;
            if (player.transform.position.x > transform.position.x)
            {
                transform.Translate(Vector2.right * speed);
            }
            else
                transform.Translate(Vector2.left * speed);
        }
        else
        {
            isAttacked = false;
        }

        if (isAttacked && !anim.GetBool("isJumping"))
        {
            SoundManager.instance.PlayHitSound();
            
            ySpeed = jumpSpeed;
            anim.SetBool("isJumping", true);
        }
        if (anim.GetBool("isJumping"))
        {
            transform.Translate(Vector2.up * ySpeed);
            ySpeed -= gravity;
        }

        if (transform.position.y < -0.65)
        {
            float x = transform.position.x;
            transform.position = new Vector2(x, (float)-0.65);
            anim.SetBool("isJumping", false);
        }

        anim.SetBool("isAttack", isAttacked);

        Debug.Log(anim.GetBool("isAttack") + " " + anim.GetBool("isAttack"));
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Jump"))
        {
            ccd.enabled = true;
        }
        else
        {
            ccd.enabled = false;
        }
        if (hp <= 0)
        {
            Destroy(GameObject.Find("GS"));
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            hp--;
        }
    }
}
