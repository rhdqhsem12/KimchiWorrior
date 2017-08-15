using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("ShowTKK", 3.0f);
        Invoke("ShowText1", 5.0f);
        Invoke("ShowText2", 10.0f);
        Invoke("DeleteAll", 12.0f);
        Invoke("Credit", 13.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowTKK()
    {
        Image img = GameObject.Find("Image").GetComponent<Image>();
        for (float i = 0; i <= 30; i += Time.deltaTime)
        {
            img.color = new Color(1f, 1f, 1f, i);
        }
    }

    void ShowText1()
    {
        Text txt = GameObject.Find("Text1").GetComponent<Text>();
        for (float i = 0; i <= 30; i += Time.deltaTime)
        {
            txt.color = new Color(0f, 0f, 0f, i);
        }
    }

    void ShowText2()
    {
        Text txt = GameObject.Find("Text2").GetComponent<Text>();
        for (float i = 0; i <= 30; i += Time.deltaTime)
        {
            txt.color = new Color(1f, 0f, 0f, i);
        }
    }
    void DeleteAll()
    {
        Destroy(GameObject.Find("Image"));
        Destroy(GameObject.Find("Text1"));
        Destroy(GameObject.Find("Text2"));
    }

    void Credit()
    {
        Text txt = GameObject.Find("Text").GetComponent<Text>();
        for (float i = 0; i <= 30; i += Time.deltaTime)
        {
            txt.color = new Color(0f, 0f, 0f, i);
        }
    }
}
