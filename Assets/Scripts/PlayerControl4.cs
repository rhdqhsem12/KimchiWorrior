using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl4 : MonoBehaviour {
    public int hp;
    public float speed;
    public float jumpSpeed;
    public float gravity;
    private float ySpeed = 0;
	private Animator anim;
    private CircleCollider2D ccd;
    bool isJumping;
    
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
        ccd = transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>();
        ccd.enabled = false;
        isJumping = false;
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
                    SceneManager.LoadScene("Ending", LoadSceneMode.Single);
                }
                float y = transform.position.y;
                transform.position = new Vector2((float)6.3, y);
            }
        }

        if (Input.GetKey("up") && !isJumping)
        {
            ySpeed = jumpSpeed;
            PsySoundManager.instance.PlayJumpSound();
            isJumping = true;
        }

        if (isJumping)
        {
            transform.Translate(Vector2.up * ySpeed);
            ySpeed -= gravity;
        }

        if (transform.position.y < -1.7)
        {
            float x = transform.position.x;
            transform.position = new Vector2(x, (float)-1.7);
            isJumping = false;
        }

        bool isAttacked = Input.GetKeyDown(KeyCode.Z);
        if (isAttacked && !anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.psy_attack"))
            PsySoundManager.instance.PlayHitSound();
        anim.SetBool("isAttack", isAttacked);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.psy_attack"))
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