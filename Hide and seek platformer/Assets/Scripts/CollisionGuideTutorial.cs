using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionGuideTutorial : MonoBehaviour {
	public string textMessage;
	private Text explanationText;
	public int triggerNumber = 0;

	public void Start() {
		explanationText = GameObject.FindWithTag("Screen Message").GetComponent<Text>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		GameObject.FindWithTag("Key Hint Tutorial " + triggerNumber).GetComponent<Renderer>().enabled = true;
		explanationText.text = textMessage;
	}
	private void OnTriggerExit2D(Collider2D other) {
		//text.text = "";
		GameObject.FindWithTag("Key Hint Tutorial " + triggerNumber).GetComponent<Renderer>().enabled = false;
	}
}