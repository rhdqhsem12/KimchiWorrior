using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public int enemyNum;
    public GameObject goArrow;

	// Use this for initialization
	void Start () {
        if (GameManager.instance == null)
            GameManager.instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(enemyNum);
        
        if(enemyNum == 0)
        {
            Instantiate(goArrow);
        }
	}
}
