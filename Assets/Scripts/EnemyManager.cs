using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    private bool isHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isHit && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isHit = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isHit = false;
    }
}
