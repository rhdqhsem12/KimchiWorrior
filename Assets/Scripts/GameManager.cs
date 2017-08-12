using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public int enemyNum;
    public GameObject goArrow;

	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }   
    }
	
	// Update is called once per frame
	void Update ()
    {
        enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        if(enemyNum == 0)
        {
            if (GameObject.Find("Go Arrow(Clone)") == null)
                Instantiate(goArrow);
        }
	}

    
}
