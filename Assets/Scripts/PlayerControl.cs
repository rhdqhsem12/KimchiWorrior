using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public float speed;
    
	// Use this for initialization
	void Start () {
		
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
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("aaa");
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Hit");
            Destroy(other.gameObject);
        }
    }
}
