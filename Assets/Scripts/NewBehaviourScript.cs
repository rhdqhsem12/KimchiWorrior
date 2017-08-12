using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
	public Slider healthBarSlider;
	public Text gameOverText;
	private bool isGameOver = false;
	// Use this for initialization
	void Start () {
		gameOverText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver)
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * 10f, 0, 0);
	}
	void OnTriggerStay(Collider other){

	{
		if (other.gameObject.name == "Hamburger" && healthBarSlider.value>0) {
			healthBarSlider.value -= 0.11f;
		} else {
			isGameOver = true;
			gameOverText.enabled = true;
		}
	}


}
}