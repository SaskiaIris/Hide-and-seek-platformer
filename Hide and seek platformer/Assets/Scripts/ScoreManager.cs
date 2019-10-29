using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public static ScoreManager instance;
	public Text carrotText;
	public Text healthPointsText;
	private int value;
	private GameObject playerObject;
	private GameObject[] carrotObjects;
	private bool isTriggered;

	void Start() {
		if(instance == null) {
			instance = this;
		}
		value = 1;
		isTriggered = false;
		playerObject = GameObject.FindWithTag("Player");
		carrotObjects = GameObject.FindGameObjectsWithTag("Carrot");
	}

	void Update() {
		carrotText.text = GameValues.Carrots.ToString();
		healthPointsText.text = GameValues.HealthPoints.ToString();
		isTriggered = false;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Carrot")) {
			if(!isTriggered) {
				isTriggered = true;
				Destroy(other.gameObject);

				GameValues.Carrots += value;
			}
		}
	}
}