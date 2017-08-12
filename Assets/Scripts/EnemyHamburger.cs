using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHamburger : MonoBehaviour {
    public int hp;
    public int speed;
    private Animator anim;
    private BoxCollider2D ccd;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        ccd = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
        ccd.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.attack"))
        {
            ccd.enabled = true;
        }
        else
        {

            ccd.enabled = false;
        }
        if (hp <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")
		{
            hp--;
        }
    }
}
