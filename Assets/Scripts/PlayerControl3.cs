using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl3 : MonoBehaviour {
    public int hp;
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
        GameObject.Find("Canvas").transform.Find("Health Bar").GetComponent<RectTransform>().sizeDelta = new Vector2(20 * hp, 100);

        if (Input.GetKey("left"))
        {
            transform.Translate(Vector2.left * speed);
            if(transform.position.x < -6.3)
            {
                float y = transform.position.y;
                transform.position = new Vector2((float)-6.3, y);
            }
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector2.right * speed);
            if (transform.position.x > 6.3)
            {
                if (GameManager.instance.enemyNum == 0)
                {
                    SceneManager.LoadScene("Boss", LoadSceneMode.Single);
                }
                float y = transform.position.y;
                transform.position = new Vector2((float)6.3, y);
            }
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
        if (hp <= 0)
        {
            BgmManager.instance.StopBgm();
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            hp--;
        }
    }
}